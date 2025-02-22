//using System.Reflection.PortableExecutable;
using HeThongQuanLiSanXuat_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLiSanXuat_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly CSDL_Quanlisanxuat dbc;
        public MachineController(CSDL_Quanlisanxuat db)
        {
            dbc = db;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var machine = await dbc.Machines.ToListAsync();

            if (machine == null || machine.Count == 0)
            {
                return NotFound(new { message = "Không có thiết bị nào trong hệ thống." });
            }

            return Ok(new {data = machine});
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] Machine machine)
        {
            if(machine == null || string.IsNullOrEmpty(machine.MachineCode)){
                return BadRequest(new { message = "Dữ liệu không hợp lệ" });
            }

            dbc.Machines.Add(machine);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Thêm thiết bị thành công", machine });
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Machine updatemachine)
        {
            if(updatemachine == null){
                return BadRequest(new { message = "Dữ liệu không hợp lệ" });
            }

            var machine = await dbc.Machines.FindAsync(id);
            if (machine == null)
            {
                return NotFound();
            }

            machine.MachineCode = updatemachine.MachineCode;
            machine.MachineName = updatemachine.MachineName;
            machine.SerialNumber = updatemachine.SerialNumber;
            machine.Capacity = updatemachine.Capacity;
            machine.Description = updatemachine.Description;

            await dbc.SaveChangesAsync();
            return Ok(new { message = "Cập nhật thiết bị thành công" , machine});
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var machine = await dbc.Machines.FindAsync(id);
            if(machine == null)
            {
                return NotFound();
            }

            dbc.Machines.Remove(machine);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Loại bỏ thiết bị thành công" });
        }
    }
}
