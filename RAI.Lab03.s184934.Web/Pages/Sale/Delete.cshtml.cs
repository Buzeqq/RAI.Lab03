using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Sale;

namespace RAI.Lab03.s184934.Web.Pages.Sale
{
    public class DeleteModel : PageModel
    {
        private readonly WarehouseDbContext _context;

        public DeleteModel(WarehouseDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SaleDto SaleDto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.SaleEntries)
                .ThenInclude(e => e.Water)
                .FirstOrDefaultAsync(m => m.Id.Equals(id));

            if (sale is null)
            {
                return NotFound();
            }

            SaleDto = sale.AsDto();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var sale = await _context.Sales
                .FindAsync(new Id(id));

            if (sale is null) return RedirectToPage("./Index");
            
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
