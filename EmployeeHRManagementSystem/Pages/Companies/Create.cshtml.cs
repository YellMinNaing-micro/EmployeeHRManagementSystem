using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP.NetCore_Test.Data;
using ASP.NetCore_Test.Entities;

namespace EmployeeHRManagementSystem.Pages.Companies
{
    public class CreateModel : PageModel
    {
        private readonly ASP.NetCore_Test.Data.EmployeeManagementSSContext _context;

        public CreateModel(ASP.NetCore_Test.Data.EmployeeManagementSSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Companies.Add(Company);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
