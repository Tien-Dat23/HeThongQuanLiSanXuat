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
            var employee = await dbc.Employees.Include(e => e.Department).ToListAsync();

            if(employee == null || employee.Count==0) {
                return BadRequest(new { message = "Không có nhân viên nào trong hệ thống" });
            }

            var result = employee.Select(e => new
            {
                e.EmployeeId,
                e.Username,
                e.Password,
                e.FullName,
                DepartmentName = e.Department?.DepartmentName
            });

            return Ok(new { data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await dbc.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }

            return Ok(new { employee });
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] Employee employee)
        {
            if(employee == null ) return BadRequest(new { message = "Dữ liệu không hợp lệ" });

            if (await dbc.Employees.AnyAsync(e => e.Username == employee.Username)) return BadRequest(new { message = "Username đã tồn tại!" });

            dbc.Employees.Add(employee);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Thêm dữ liệu nhân viên thành công", employee});
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee updateEmployee)
        {
            if(updateEmployee == null) {
                return BadRequest(new
                {
                    message = "Dữ liệu không hợp lệ"
                });
            }

            var employee = await dbc.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }

            employee.Username = updateEmployee.Username;
            employee.Password = updateEmployee.Password;
            employee.FullName = updateEmployee.FullName;
            employee.DepartmentId = updateEmployee.DepartmentId;

            await dbc.SaveChangesAsync();
            return Ok(new { message = "Cập nhật nhân viên thành công", employee });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await dbc.Employees.FindAsync(id);
            if(employee == null) {
                return NotFound();
            }

            dbc.Employees.Remove(employee);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Xóa nhân viên thành công." });
        }
    }
}
