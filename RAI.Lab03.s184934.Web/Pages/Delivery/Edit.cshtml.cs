using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Delivery;

namespace RAI.Lab03.s184934.Web.Pages.Delivery
{
    public class EditModel : PageModel
    {
        private readonly WarehouseDbContext _context;

        public EditModel(WarehouseDbContext context)
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

            var delivery =  await _context.Deliveries.FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (delivery is null)
            {
                return NotFound();
            }
            Delivery = delivery.AsDto();
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

            _context.Attach(Delivery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(Delivery.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool DeliveryExists(Id id)
        {
          return (_context.Deliveries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
