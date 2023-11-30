using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;
using RAI.Lab03.s184934.Web.Data.DTO.Sale;

namespace RAI.Lab03.s184934.Web.Pages.Sale
{
    public class DetailsModel : PageModel
    {
        private readonly WarehouseDbContext _context;

        public DetailsModel(WarehouseDbContext context)
        {
            _context = context;
        }

      public SaleDto Sale { get; set; } = default!; 
      public IEnumerable<SaleEntryDto> SaleEntryDtos { get; set; }
      public IEnumerable<MineralWaterDto> Waters { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.SaleEntries)
                .ThenInclude(s => s.Water)
                .SingleOrDefaultAsync(m => m.Id.Equals(id));
            if (sale is null)
            {
                return NotFound();
            }
            
            SaleEntryDtos = sale.SaleEntries.Select(e => e.AsDto());
            Sale = sale.AsDto();
            Waters = sale.SaleEntries
                .Select(p => p.Water)
                .Select(w => new MineralWaterDto
                {
                    Id = w.Id,
                    Name = w.Name
                })
                .DistinctBy(w => w.Id)
                .ToList();
            return Page();
        }
    }
}
