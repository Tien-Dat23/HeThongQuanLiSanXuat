using System.Threading.Tasks;
using HeThongQuanLiSanXuat_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HeThongQuanLiSanXuat_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly CSDL_Quanlisanxuat dbc;
        public DepartmentController(CSDL_Quanlisanxuat db)
        {
            dbc = db;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var department = await dbc.Departments.ToListAsync();
            return Ok(new { data = department });
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] Department department)
        {
            if(department == null)
            {
                return BadRequest(new { message = "Dữ liệu không hợp lệ" });
            }

            dbc.Departments.Add(department);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Thêm phòng ban thành công", department });
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Department updateDepartment)
        {
            if(updateDepartment == null)
            {
                return BadRequest("Dữ liệu không hợp lệ");
            }

            var department = await dbc.Departments.FindAsync(id);
            if(department == null)
            {
                return NotFound();
            }

            department.DepartmentCode = updateDepartment.DepartmentCode;
            department.DepartmentName = updateDepartment.DepartmentName;
            department.Description = updateDepartment.Description;

            await dbc.SaveChangesAsync();
            return Ok(new { message = "Cập nhật dữ liệu phòng ban thành công", department });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await dbc.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound(new { message = "Phòng ban không tồn tại" });
            }

            dbc.Departments.Remove(department);
            await dbc.SaveChangesAsync();

            return Ok(new { message = "Xóa phòng ban thành công" });
        }
    }
}
