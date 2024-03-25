using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP.NetCore_Test.Data;
using ASP.NetCore_Test.Entities;

namespace EmployeeHRManagementSystem.Pages.Companies
{
    public class DetailsModel : PageModel
    {
        private readonly ASP.NetCore_Test.Data.EmployeeManagementSSContext _context;

        public DetailsModel(ASP.NetCore_Test.Data.EmployeeManagementSSContext context)
        {
            _context = context;
        }

        public Company Company { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }
            else
            {
                Company = company;
            }
            return Page();
        }
    }
}
