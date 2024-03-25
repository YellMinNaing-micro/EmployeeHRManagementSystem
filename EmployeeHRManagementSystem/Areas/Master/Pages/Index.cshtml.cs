using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeHRManagementSystem.Areas.Master.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ASP.NetCore_Test.Data.EmployeeManagementSSContext _context;

        public IndexModel(ASP.NetCore_Test.Data.EmployeeManagementSSContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
    }
}
