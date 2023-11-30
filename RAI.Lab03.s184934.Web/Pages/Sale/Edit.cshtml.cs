using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;
using RAI.Lab03.s184934.Web.Data.DTO.Sale;

namespace RAI.Lab03.s184934.Web.Pages.Sale
{
    public class EditModel : PageModel
    {
        private readonly WarehouseDbContext _context;

        public EditModel(WarehouseDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SaleDto SaleDto { get; set; } = default!;
        
        public IEnumerable<SaleEntryDto> SaleEntryDtos { get; set; }
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
            var sale =  await _context.Sales
                .Include(d => d.SaleEntries)
                .FirstOrDefaultAsync(m => m.Id.Equals(id));

            SaleEntryDtos = await _context.SaleEntries
                .AsNoTracking()
                .Include(p => p.Water)
                .Where(p => sale!.SaleEntries.Select(pa => pa.Id).Contains(p.Id))
                .Select(p => p.AsDto())
                .ToListAsync();
            
            if (sale is null)
            {
                return NotFound();
            }
            SaleDto = sale.AsDto();
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

            _context.Attach(SaleDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(SaleDto.Id))
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
