using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;
using RAI.Lab03.s184934.Web.Data.DTO.Ion;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;
using RAI.Lab03.s184934.Web.Data.DTO.Packaging;
using RAI.Lab03.s184934.Web.Data.DTO.WaterType;

namespace RAI.Lab03.s184934.Web.Pages.Water;

public class EditModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public EditModel(WarehouseDbContext context)
    {
        _context = context;
        AvailableWaterTypes = _context.WaterTypes.AsNoTracking().Select(t => t.AsDto()).ToList();
        AvailableAnions = _context.Anions.AsNoTracking().Select(a => a.AsDto()).ToList();
        AvailableCations = _context.Cations.AsNoTracking().Select(c => c.AsDto()).ToList();
        AvailablePackaging = _context.Packaging.AsNoTracking().Select(p => p.AsDto()).ToList();
        AvailableProducers = _context.Producers.AsNoTracking().Select(p => p.AsDto()).ToList();
    }

    [BindProperty]
    public MineralWaterDto MineralWaterDto { get; set; } = default!;
    public IEnumerable<CompanyDto> AvailableProducers { get; set; }
    public IEnumerable<PackagingDto> AvailablePackaging { get; set; }
    public IEnumerable<WaterTypeDto> AvailableWaterTypes { get; set; }
    public IEnumerable<IonDto> AvailableAnions { get; set; }
    public IEnumerable<IonDto> AvailableCations { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        var mineralWater =  await _context.MineralWaters
            .AsNoTracking()
            .Include(w => w.Producer)
            .Include(w => w.Packaging)
            .Include(w => w.Anions)
            .Include(w => w.Cations)
            .Include(w => w.Type)
            .SingleOrDefaultAsync(m => m.Id == new Id(id));
        if (mineralWater is null)
        {
            return NotFound();
        }
        MineralWaterDto = mineralWater.AsDto();
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // ReSharper disable once EntityFramework.NPlusOne.IncompleteDataQuery
        var mineralWater =  (await _context.MineralWaters
            .Include(w => w.Producer)
            .Include(w => w.Packaging)
            .Include(w => w.Anions)
            .Include(w => w.Cations)
            .Include(w => w.Type)
            .SingleOrDefaultAsync(m => m.Id == new Id(MineralWaterDto.Id)))!;

        // ReSharper disable once EntityFramework.NPlusOne.IncompleteDataUsage
        if (!mineralWater.Type.Id.Equals(MineralWaterDto.Type))
        {
            mineralWater.Type = _context.WaterTypes.Single(t => t.Id.Equals(MineralWaterDto.Type));
        }

        // ReSharper disable once EntityFramework.NPlusOne.IncompleteDataUsage
        if (!mineralWater.Packaging.Id.Equals(MineralWaterDto.Packaging))
        {
            mineralWater.Packaging = _context.Packaging.Single(p => p.Id.Equals(MineralWaterDto.Packaging));
        }

        // ReSharper disable once EntityFramework.NPlusOne.IncompleteDataUsage
        if (!mineralWater.Producer.Id.Equals(MineralWaterDto.Producer))
        {
            mineralWater.Producer = _context.Producers.Single(p => p.Id.Equals(MineralWaterDto.Producer));    
        }
        
        mineralWater.Anions.Clear();
        mineralWater.Anions.AddRange(_context.Anions
                .Where(a => MineralWaterDto.Anions.Contains(a.Id)));
        
        mineralWater.Cations.Clear();
        mineralWater.Cations.AddRange(_context.Cations
                .Where(c => MineralWaterDto.Cations.Contains(c.Id)));

        _context.MineralWaters.Update(mineralWater);
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MineralWaterExists(MineralWaterDto.Id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool MineralWaterExists(Id id)
    {
        return (_context.MineralWaters?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}