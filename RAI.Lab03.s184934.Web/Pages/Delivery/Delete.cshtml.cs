using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Delivery;

namespace RAI.Lab03.s184934.Web.Pages.Delivery
{
    public class DeleteModel : PageModel
    {
        private readonly WarehouseDbContext _context;

        public DeleteModel(WarehouseDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DeliveryDto Delivery { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries
                .Include(d => d.Supplier)
                .Include(d => d.Pallets)
                .FirstOrDefaultAsync(m => m.Id.Equals(id));

            if (delivery is null)
            {
                return NotFound();
            }

            Delivery = delivery.AsDto();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var delivery = await _context.Deliveries
                .FindAsync(new Id(id));

            if (delivery == null) return RedirectToPage("./Index");
            
            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
