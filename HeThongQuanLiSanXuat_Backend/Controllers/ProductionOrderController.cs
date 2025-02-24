using HeThongQuanLiSanXuat_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HeThongQuanLiSanXuat_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionOrderController : ControllerBase
    {
        private readonly CSDL_Quanlisanxuat dbc;

        public ProductionOrderController(CSDL_Quanlisanxuat db)
        {
            dbc = db;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var productorder = await dbc.ProductionOrders.ToListAsync();
            return Ok(new { data =  productorder });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productorder = await dbc.ProductionOrders.FindAsync(id);
            if (productorder == null)
            {
                return NotFound(new { message = "Sản phẩm không tồn tại" });
            }
            return Ok(new{ productorder });
        }


        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] ProductionOrder productionOrder)
        {
            if(productionOrder == null || string.IsNullOrEmpty(productionOrder.OrderCode)){
                return BadRequest(new { message = "Dữ liệu lệnh sản xuất không hợp lệ"});
            }


            dbc.ProductionOrders.Add(productionOrder);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Lệnh sản xuất đã được tạo thành công", productionOrder });
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductionOrder updatedProductionOrder)
        {
            if(updatedProductionOrder == null)
            {
                return BadRequest(new { message = "Dữ liệu không hợp lệ" });
            }

            var productOrder = await dbc.ProductionOrders.FindAsync(id);
            if(productOrder == null)
            {
                return NotFound(new { message = "Sản phẩm không tồn tại" });
            }

            productOrder.OrderCode = updatedProductionOrder.OrderCode;
            productOrder.OrderName = updatedProductionOrder.OrderName;
            productOrder.Quantity = updatedProductionOrder.Quantity;
            productOrder.Description = updatedProductionOrder.Description;
            productOrder.StartDate = updatedProductionOrder.StartDate;
            productOrder.EndDate = updatedProductionOrder.EndDate;

            await dbc.SaveChangesAsync();
            return Ok(new { message = "Cập nhật thành công" , productOrder});
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productionOrder = await dbc.ProductionOrders.FindAsync(id);
            if(productionOrder == null)
            {
                return NotFound(new { message = "Lệnh sản xuất không tồn tại" });
            }

            dbc.ProductionOrders.Remove(productionOrder);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Lệnh sản xuất được xóa thành công"});
        }
    }
}
