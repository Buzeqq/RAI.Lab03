using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;
using RAI.Lab03.s184934.Web.Data.DTO.Delivery;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;

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
      public CompanyDto Supplier { get; set; }
      public IEnumerable<PalletDto> Pallets { get; set; }
      public IEnumerable<MineralWaterDto> Waters { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries
                .Include(d => d.Supplier)
                .Include(d => d.Pallets)
                .ThenInclude(p => p.Water)
                .SingleOrDefaultAsync(m => m.Id.Equals(id));
            if (delivery is null)
            {
                return NotFound();
            }
            
            Supplier = delivery.Supplier.AsDto();
            Pallets = delivery.Pallets.Select(p => p.AsDto()).ToList();
            Delivery = delivery.AsDto();
            Waters = delivery.Pallets
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
