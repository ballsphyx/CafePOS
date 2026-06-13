using CafePOS_API.Models.DTOs.QueryParams;
using CafePOS_API.Models.DTOs.Requests;
using CafePOS_API.Models.DTOs.Response;
using CafePOS_API.Services.Implementations;
using CafePOS_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafePOS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService _service) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProduct(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<ProductResponse>> PostProduct(ProductRequest dto)
        {
            var result = await _service.AddProductAsync(dto);
            return CreatedAtAction(nameof(GetProduct), new {id = result.Id}, result);
        }
        [HttpPost("{id}/stocks")]
        public async Task<IActionResult> PostStocks(int id, int quantity)
        {
            var result = await _service.AdjustProductInventory(id, quantity);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductRequest dto)
        {
            var result = await _service.UpdateProductAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _service.DeleteProductAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<ProductResponse>> GetAll([FromQuery] ProductQueryParam query)
        {
            var product = await _service.GetAllAsync(query);
            return Ok(product);
        }
    }
}
