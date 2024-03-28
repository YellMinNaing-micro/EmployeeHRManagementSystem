using ASP.NetCore_Test.Data;
using ASP.NetCore_Test.Entities;
using EmployeeHRManagementSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;


namespace EmployeeHRManagementSystem.Areas.Master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController(EmployeeManagementSSContext context) : ControllerBase
    {
        private readonly EmployeeManagementSSContext _context = context;

        [HttpGet("GetData")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var list = await _context.Employees.ToListAsync();
                return Ok(new ResModels()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Success = true,
                    Data = list,
                    Message = "Success"
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResModels()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Success = false,
                    Data = "",
                    Message = ex.Message
                });
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateEmployee([FromForm] ASP.NetCore_Test.Entities.Employee emp)
        {
            if (_context.Employees.Count() > 0)
            {
                emp.EmployeeId = await _context.Employees.MaxAsync(s => s.EmployeeId) + 1;
            }
            else
            {
                emp.EmployeeId = 1;
            }
            ASP.NetCore_Test.Entities.Employee employee = new()
            {
                EmployeeId = emp.EmployeeId,
                EmployeeName = emp.EmployeeName,
                CompanyName = emp.CompanyName,
                Deparment = emp.Deparment,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(new ResModels()
            {
                StatusCode = StatusCodes.Status200OK,
                Success = true,
                Data = employee,
                Message = "Success"
            });
        }
        [HttpGet("employee/NameExists")]
        public async Task<IActionResult> CheckNameExitst(string EmployeeName)
        {
            try
            {
                ASP.NetCore_Test.Entities.Employee? employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeName == EmployeeName);
                return (employee != null)
                   ? Ok(new ResModels()
                   {
                       StatusCode = StatusCodes.Status200OK,
                       Success = true,
                       Data = "",
                       Message = "Employee Name is already existed",
                       exists = true
                   })
                   : Ok(new ResModels()
                   {
                       StatusCode = StatusCodes.Status200OK,
                       Success = true,
                       Data = "",
                       Message = "",
                       exists = false
                   });
                    
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResModels()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Success = false,
                    Data = "",
                    Message = ex.Message
                });
            }
            {

            }
        }
        [HttpGet("Employee/byid")]
        public async Task<IActionResult> GetEmployeebyid(int EmployeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(s => s.EmployeeId == EmployeeId);
            return Ok(new ResModels()
            {

                StatusCode = StatusCodes.Status200OK,
                Success = true,
                Data = employee,
                Message = "Success"
            });
        }
        [HttpPut("Employee/Edit")]
        public async Task<IActionResult> EditEmployee([FromForm] ASP.NetCore_Test.Entities.Employee emp)
        {
            try
            {
                ASP.NetCore_Test.Entities.Employee? employee = await _context.Employees.FirstOrDefaultAsync(s => s.EmployeeId == emp.EmployeeId);
                if (employee != null)
                {
                    employee.EmployeeId = emp.EmployeeId;
                    employee.EmployeeName = emp.EmployeeName;
                    employee.CompanyName = emp.CompanyName;
                    employee.Deparment = emp.Deparment;
                    employee.UpdatedOn = DateTime.Now;
                }
                _context.Attach(employee).State = EntityState.Modified;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(new ResModels()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Success = true,
                        Data = new { message = "Successfully Edit" },
                        Message = "Success"
                    });
                }
                else
                {
                    return BadRequest(new ResModels()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Data = null,
                        Success = false,
                        Message = "Message Req faill"
                    });
                }
            }
            catch (Exception exp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResModels()
                {
                    Success = false,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null,
                    Message = exp.Message
                });
            }
        }
        [HttpDelete("Employee/delete")]
        public async Task<IActionResult> DeleteEmployee(int EmployeeID)
        {

            try
            {
                ASP.NetCore_Test.Entities.Employee? employee = await _context.Employees.FindAsync(EmployeeID);

                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();

                    return Ok(new ResModels()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Success = true,
                        Data = employee,
                        Message = "Successfully delete data"
                    });

                }
                else
                {
                    return BadRequest(new ResModels()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Success = false,
                        Data = null,
                        Message = "Delete Data unsuccessfully!"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResModels()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Success = false,
                    Data = null,
                    Message = ex.Message
                });
            }
        }

    }
}
