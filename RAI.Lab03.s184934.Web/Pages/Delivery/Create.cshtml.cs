using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;
using RAI.Lab03.s184934.Web.Data.DTO.Delivery;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;

namespace RAI.Lab03.s184934.Web.Pages.Delivery
{
    public class CreateModel : PageModel
    {
        private readonly WarehouseDbContext _context;

        public CreateModel(WarehouseDbContext context)
        {
            _context = context;
            AvailableSuppliers = _context.Supplier.AsNoTracking().Select(s => s.AsDto()).ToList();
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
        public DeliveryDto DeliveryDto { get; set; } = default!;

        [BindProperty] 
        public IList<PalletDto> PalletDtos { get; set; } = default!;
        
        public IEnumerable<CompanyDto> AvailableSuppliers { get; set; }
        public IEnumerable<MineralWaterDto> AvailableMineralWaterDtos { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var pallets = PalletDtos
                .Select(p =>
                {
                    var pallet = p.AsPallet(Guid.NewGuid());
                    pallet.Water = _context.MineralWaters.Single(w => w.Id.Equals(p.WaterId));
                    return pallet;
                })
                .ToList();
            await _context.Pallets.AddRangeAsync(pallets);
            DeliveryDto.Pallets = pallets.Select(p => p.Id.Value).ToList();
            var delivery = DeliveryDto.AsDelivery(Guid.NewGuid());
            delivery.Pallets = pallets;
            delivery.Supplier = await _context.Supplier.SingleAsync(s => s.Id.Equals(DeliveryDto.Supplier));
            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
