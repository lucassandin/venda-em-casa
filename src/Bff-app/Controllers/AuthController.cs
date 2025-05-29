using Auth.DTOs;
using Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BffApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var result = await _authService.LoginAsync(request);
            if (result == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos." });

            return Ok(result);
        }
    }
}
