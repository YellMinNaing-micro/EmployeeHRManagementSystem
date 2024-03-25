using ASP.NetCore_Test.Data;
using ASP.NetCore_Test.Entities;
using EmployeeHRManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeHRManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly EmployeeManagementSSContext _context;
        public CompanyController(EmployeeManagementSSContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromForm] Company com)
        {

            Company company = new()
            {
                CompanyId = com.CompanyId,
                CompanyName = com.CompanyName,
                Address = com.Address,
                Email = com.Email,
                Phone = com.Phone,
            };
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return Ok(new ResModels()
            {
                StatusCode = StatusCodes.Status200OK,
                Success = true,
                Data = company,
                Message = "Request"
            });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updatecompany(int id, [FromForm] Company com)
        {
            if (id != com.CompanyId)
            {
                return BadRequest("company id required");
            }

            var companytoupdate = await _context.Companies.FindAsync(id);
            if (companytoupdate == null)
            {
                return NotFound($"company with id = {id} not found.");
            }

            companytoupdate.CompanyName = com.CompanyName;
            companytoupdate.Address = com.Address;
            companytoupdate.Email = com.Email;
            companytoupdate.Phone = com.Phone;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Companies.Any(e => e.CompanyId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new ResModels()
            {
                StatusCode = StatusCodes.Status200OK,
                Success = true,
                Data = companytoupdate,
                Message = "company updated successfully"
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var companyToDelete = await _context.Companies.FindAsync(id);
            if (companyToDelete == null)
            {
                return NotFound($"Company with id = {id} not found.");
            }

            _context.Companies.Remove(companyToDelete);
            await _context.SaveChangesAsync();

            return Ok(new ResModels()
            {
                StatusCode = StatusCodes.Status200OK,
                Success = true,
                Data = "",
                Message = "Company deleted successfully"
            });
        }

    }
}


