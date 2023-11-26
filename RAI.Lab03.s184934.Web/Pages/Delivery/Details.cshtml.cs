using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Delivery;

namespace RAI.Lab03.s184934.Web.Pages.Delivery
{
    public class DetailsModel : PageModel
    {
        private readonly WarehouseDbContext _context;

        public DetailsModel(WarehouseDbContext context)
        {
            _context = context;
        }

      public DeliveryDto Delivery { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries.FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (delivery is null)
            {
                return NotFound();
            }

            Delivery = delivery.AsDto();
            return Page();
        }
    }
}
