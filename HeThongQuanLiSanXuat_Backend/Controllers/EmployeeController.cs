using System.Runtime.InteropServices;
using HeThongQuanLiSanXuat_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HeThongQuanLiSanXuat_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CSDL_Quanlisanxuat dbc;
        public EmployeeController(CSDL_Quanlisanxuat db)
        {
            dbc = db;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var employee = await dbc.Employees
                                    .Include(e => e.Department)                    
                                    .ToListAsync();
            if(employee == null || employee.Count==0) {
                return BadRequest(new { message = "Không có nhân viên nào trong hệ thống" });
            }

            var result = employee.Select(e => new
            {
                e.Username,
                e.Password,
                e.FullName,
                e.DepartmentId,
                DepartmentName = e.Department?.DepartmentName // Lấy tên phòng ban
            });

            return Ok(new { data = result });
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] Employee employee)
        {
            if(employee == null )
            {
                return BadRequest(new { message = "Dữ liệu không hợp lệ" });
            }

            dbc.Employees.Add(employee);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Thêm dữ liệu nhân viên thành công", employee});
        }

        [HttpPut("Update/{username}")]
        public async Task<IActionResult> Update(string username, [FromBody] Employee updateEmployee)
        {
            if(updateEmployee == null) {
                return BadRequest(new
                {
                    message = "Dữ liệu không hợp lệ"
                });
            }

            var employee = await dbc.Employees.FindAsync(username);
            if(employee == null)
            {
                return NotFound();
            }

            employee.Password = updateEmployee.Password;
            employee.FullName = updateEmployee.FullName;
            employee.DepartmentId = updateEmployee.DepartmentId;

            await dbc.SaveChangesAsync();
            return Ok(new { message = "Cập nhật nhân viên thành công", employee });
        }

        [HttpDelete("Delete/{username}")]
        public async Task<IActionResult> Delete(string username)
        {
            var employee = await dbc.Employees.FindAsync(username);
            if(employee == null) {
                return NotFound();
            }

            dbc.Employees.Remove(employee);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Xóa nhân viên thành công." });
        }
    }
}
