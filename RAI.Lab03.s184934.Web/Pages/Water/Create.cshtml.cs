using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;
using RAI.Lab03.s184934.Web.Data.DTO.Ion;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;
using RAI.Lab03.s184934.Web.Data.DTO.Packaging;
using RAI.Lab03.s184934.Web.Data.DTO.WaterType;

namespace RAI.Lab03.s184934.Web.Pages.Water;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
        AvailableWaterTypes = _context.WaterTypes.Select(t => t.AsDto()).ToList();
        AvailableAnions = _context.Anions.Select(a => a.AsDto()).ToList();
        AvailableCations = _context.Cations.Select(c => c.AsDto()).ToList();
        AvailablePackaging = _context.Packaging.Select(p => p.AsDto()).ToList();
        AvailableProducers = _context.Producers.Select(p => p.AsDto()).ToList();
    }

    public IActionResult OnGet()
    {
        MineralWaterDto = new MineralWaterDto();
        return Page();
    }

    [BindProperty]
    public MineralWaterDto MineralWaterDto { get; set; } = default!;
    public IEnumerable<CompanyDto> AvailableProducers { get; set; }
    public IEnumerable<PackagingDto> AvailablePackaging { get; set; }
    public IEnumerable<WaterTypeDto> AvailableWaterTypes { get; set; }
    public IEnumerable<IonDto> AvailableAnions { get; set; }
    public IEnumerable<IonDto> AvailableCations { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var newWater = MineralWaterDto.AsMineralWater(Guid.NewGuid());
        newWater.Anions.AddRange(_context.Anions.Where(a => MineralWaterDto.Anions.Contains(a.Id)));
        newWater.Cations.AddRange(_context.Cations.Where(a => MineralWaterDto.Cations.Contains(a.Id)));
        newWater.Packaging = (await _context.Packaging.SingleOrDefaultAsync(p => p.Id.Equals(MineralWaterDto.Packaging)))!;
        newWater.Producer =
            (await _context.Producers.SingleOrDefaultAsync(p => p.Id.Equals(MineralWaterDto.Producer)))!;
        newWater.Type = (await _context.WaterTypes.SingleOrDefaultAsync(t => t.Id.Equals(MineralWaterDto.Type)))!;
            
        _context.MineralWaters.Add(newWater);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}