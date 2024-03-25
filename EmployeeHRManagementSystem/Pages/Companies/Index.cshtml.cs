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
    public class IndexModel : PageModel
    {
        private readonly ASP.NetCore_Test.Data.EmployeeManagementSSContext _context;

        public IndexModel(ASP.NetCore_Test.Data.EmployeeManagementSSContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Company = await _context.Companies.ToListAsync();
        }
    }
}
