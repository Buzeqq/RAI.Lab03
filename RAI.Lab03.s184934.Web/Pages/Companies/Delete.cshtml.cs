using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;

namespace RAI.Lab03.s184934.Web.Pages.Companies
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CompanyDto Company { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var company = await _context.Companies.FirstOrDefaultAsync(m => m.Id == new Id(id));

            if (company is null)
            {
                return NotFound();
            }

            Company = new CompanyDto(company.Id,
                company.Name,
                company.PhoneNumber,
                company.Email,
                company.GetCompanyType());
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var company = await _context.Companies.FindAsync(new Id(id));

            if (company == null) return RedirectToPage("./Index");
            
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
