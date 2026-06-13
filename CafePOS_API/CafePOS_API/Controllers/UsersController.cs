using CafePOS_API.Models.DTOs.Response;
using CafePOS_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafePOS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class UsersController(IEmployeeService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetEmployees()
        {
            var responses = await _service.GetAllAsync();

            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponse>> GetEmployee(string id)
        {
            var response = await _service.GetByIdAsync(id);

            return Ok(response);
        }
    }
}
