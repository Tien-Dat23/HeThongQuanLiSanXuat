using HeThongQuanLiSanXuat_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HeThongQuanLiSanXuat_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {

        private readonly CSDL_Quanlisanxuat dbc;
        public StageController(CSDL_Quanlisanxuat db)
        {
            dbc = db;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var stage = await dbc.Stages.ToListAsync();
            return Ok(new { data = stage });
        }

        [HttpPost("Inset")]
        public async Task<IActionResult> Insert([FromBody] Stage stage)
        {
            if(stage == null || string.IsNullOrEmpty(stage.StageCode))
            {
                return BadRequest(new { message = "Dữ liệu không hợp lệ" });
            }

            dbc.Stages.Add(stage);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Thêm công đoạn thành công", stage });
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Stage updatedStage)
        {
            if (updatedStage == null)
            {
                return BadRequest(new { message = "Dữ liệu không hợp lệ" });
            }

            var stage = await dbc.Stages.FindAsync(id);
            if (stage == null)
            {
                return NotFound();
            }

            stage.StageCode = updatedStage.StageCode;
            stage.StageName = updatedStage.StageName;
            stage.Description = updatedStage.Description;

            await dbc.SaveChangesAsync();
            return Ok(new { message = "Cập nhật công đoạn thành công", stage });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stage = await dbc.Stages.FindAsync(id);
            if(stage == null)
            {
                return NotFound();
            }

            dbc.Stages.Remove(stage);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Xóa công đoạn thành công." });
        }
    }
}
