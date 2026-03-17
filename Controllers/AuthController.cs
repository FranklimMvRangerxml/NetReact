using Microsoft.AspNetCore.Mvc;
using carritonet.Models;
using carritonet.Services;  // ✅ AGREGAR
// using BCrypt.Net;         // ❌ ELIMINAR — no se usa aquí

namespace carritonet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;//Services

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _authService.LoginAsync(loginDto);

            if (resultado == null)
                return Unauthorized(new { mensaje = "Correo o contraseña incorrectos" });

            return Ok(resultado);
        }
    }
}