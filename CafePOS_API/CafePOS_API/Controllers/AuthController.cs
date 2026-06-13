using CafePOS_API.Models.DTOs.Requests;
using CafePOS_API.Models.DTOs.Response;
using CafePOS_API.Models.Entities;
using CafePOS_API.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CafePOS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(TokenService tokenService, UserManager<Employee> userManager, SignInManager<Employee> signInManager) : ControllerBase
    {
        [HttpPost("cashier/register")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> RegisterCashier([FromBody] RegisterRequest request)
        {
            var user = new Employee
            {
                FullName = request.fullName,
                Email = request.email,
                PasswordHash = request.password,
                UserName = request.email
            };

            var result = await userManager.CreateAsync(user, request.password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            await userManager.AddToRoleAsync(user, "Cashier");

            var roles = await userManager.GetRolesAsync(user);
            var tokens = await tokenService.GenerateTokenAsync(user);

            return CreatedAtAction(nameof(RegisterCashier), new AuthResponse(tokens, user.Email, user.FullName, roles));
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.email);
            if (user == null) return Unauthorized(new { message = "Invalid Credentials" });

            var result = await signInManager.CheckPasswordSignInAsync(user, request.password, lockoutOnFailure: true);

            if (result.IsLockedOut) return StatusCode(423, new { message = "Account is locked out. Try again later" });
            if (!result.Succeeded) return Unauthorized(new { message = "Invalid Credentials" });

            var roles = await userManager.GetRolesAsync(user);
            var token = await tokenService.GenerateTokenAsync(user);

            return Ok(new AuthResponse(token, user.Email!, user.FullName, roles));
        }
    }
}
