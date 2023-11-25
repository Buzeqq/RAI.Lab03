using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;

namespace RAI.Lab03.s184934.Web.Pages.Companies
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Company? Company { get; set; }
        [BindProperty]
        public CompanyDto CompanyDto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            Company = await _context.Companies.FirstOrDefaultAsync(m => m.Id == (Id)id);
            if (Company is null)
            {
                return NotFound();
            }

            CompanyDto = new CompanyDto(Company.Id, Company.Name, Company.PhoneNumber, Company.Email, Company.GetCompanyType());
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
            var (id, name, phone, email, _) = CompanyDto;
            Company = await _context.Companies.FirstOrDefaultAsync(m => m.Id == new Id(id));
            if (Company is null)
            {
                return NotFound();
            }

            try
            {
                Company.Name = name;
                Company.PhoneNumber = phone;
                Company.Email = email;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            _context.Attach(Company).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(Company.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool CompanyExists(Id id)
        {
            return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
