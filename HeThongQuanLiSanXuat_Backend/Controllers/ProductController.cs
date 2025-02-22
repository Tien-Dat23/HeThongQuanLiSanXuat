using HeThongQuanLiSanXuat_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HeThongQuanLiSanXuat_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CSDL_Quanlisanxuat dbc;

        public ProductController(CSDL_Quanlisanxuat db)
        {
            dbc = db;
        }

        // GET /Product/List
        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var products = await dbc.Products.ToListAsync();
            return Ok(new { data = products });
        }

        // 2. POST
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] Product product)
        {
            if (product == null || string.IsNullOrEmpty(product.ProductCode))
            {
                return BadRequest(new { message = "Dữ liệu sản phẩm không hợp lệ." });
            }

            dbc.Products.Add(product);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Sản phẩm đã được tạo thành công", product });
        }

        // 3. PUT
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product updatedProduct)
        {
            if (updatedProduct == null)
            {
                return BadRequest(new { message = "Dữ liệu cập nhật không hợp lệ." });
            }

            var product = await dbc.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Sản phẩm không tồn tại." });
            }

            // Cập nhật các thuộc tính
            product.ProductName = updatedProduct.ProductName;
            product.Unit = updatedProduct.Unit;
            product.Description = updatedProduct.Description;

            await dbc.SaveChangesAsync();
            return Ok(new { message = "Cập nhật thành công.", product });
        }

        // 4. DELETE
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await dbc.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Sản phẩm không tồn tại." });
            }

            dbc.Products.Remove(product);
            await dbc.SaveChangesAsync();
            return Ok(new { message = "Đã xóa sản phẩm thành công." });
        }
    }
}
