using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;
using RAI.Lab03.s184934.Web.Data.DTO.Sale;

namespace RAI.Lab03.s184934.Web.Pages.Sale;

public class CreateModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public CreateModel(WarehouseDbContext context)
    {
        _context = context;
        AvailableMineralWaterDtos = _context.MineralWaters
            .AsNoTracking()
            .Include(w => w.Packaging)
            .Include(w => w.Anions)
            .Include(w => w.Cations)
            .Include(w => w.Producer)
            .Include(w => w.Type)
            .Select(s => s.AsDto()).ToList();
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public SaleDto SaleDto { get; set; } = default!;
    [BindProperty]
    public IList<SaleEntryDto> SaleEntryDtos { get; set; }
    public IEnumerable<MineralWaterDto> AvailableMineralWaterDtos { get; set; }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var saleEntries = SaleEntryDtos
            .Select(e =>
            {
                var entry = e.AsSaleEntry(Guid.NewGuid());
                entry.Water = _context.MineralWaters.Single(w => w.Id.Equals(e.WaterId));
                return entry;
            })
            .ToList();
        await _context.SaleEntries.AddRangeAsync(saleEntries);
        SaleDto.SaleEntries = SaleEntryDtos;
        var sale = SaleDto.AsSale(Guid.NewGuid());
        sale.SaleEntries = saleEntries;
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}