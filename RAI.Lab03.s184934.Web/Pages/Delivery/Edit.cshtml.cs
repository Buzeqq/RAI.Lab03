using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;
using RAI.Lab03.s184934.Web.Data.DTO.Delivery;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;

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
        public DeliveryDto DeliveryDto { get; set; } = default!;
        
        public IEnumerable<PalletDto> PalletDtos { get; set; }
        public IEnumerable<CompanyDto> AvailableSuppliers { get; set; }
        public IEnumerable<MineralWaterDto> AvailableMineralWaterDtos { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            AvailableMineralWaterDtos = await _context.MineralWaters
                .AsNoTracking()
                .Include(w => w.Packaging)
                .Include(w => w.Anions)
                .Include(w => w.Cations)
                .Include(w => w.Producer)
                .Include(w => w.Type)
                .Select(s => s.AsDto()).ToListAsync();
            AvailableSuppliers = await _context.Supplier
                .AsNoTracking()
                .Select(s => s.AsDto())
                .ToListAsync();
            var delivery =  await _context.Deliveries
                .Include(d => d.Supplier)
                .Include(d => d.Pallets)
                .FirstOrDefaultAsync(m => m.Id.Equals(id));

            PalletDtos = await _context.Pallets
                .AsNoTracking()
                .Include(p => p.Water)
                .Where(p => delivery!.Pallets.Select(pa => pa.Id).Contains(p.Id))
                .Select(p => p.AsDto())
                .ToListAsync();
            
            if (delivery is null)
            {
                return NotFound();
            }
            DeliveryDto = delivery.AsDto();
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

            _context.Attach(DeliveryDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(DeliveryDto.Id))
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
