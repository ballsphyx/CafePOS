using CafePOS_API.Models.DTOs.Requests;
using CafePOS_API.Models.DTOs.Response;
using CafePOS_API.Models.Entities;
using CafePOS_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafePOS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrders()
        {
            var orders = await _service.GetAllOrdersAsync();
            if (orders == null) return NotFound();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrder(int id)
        {
            return Ok(await _service.GetOrderAsync(id));
        }
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> PostOrder(OrderRequest orderRequest)
        {
            var result = await _service.CreateOrder(orderRequest);
            return CreatedAtAction(nameof(GetOrder), new { id = result.Id }, result);
        }
    }
}
