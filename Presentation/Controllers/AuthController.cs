using Application.Abstractions.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly Serilog.ILogger _logger;

        public AuthController(Serilog.ILogger logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            try
            {
                _logger.Information($"Registering new user :{request.Email}");
                var result = await _authService.RegisterAsync(request.Email, request.Password, request.Fullname);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.Error($"Error while Registering new user :{request.Email}, {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                _logger.Information($"Loging in user :{request.Email}");
                var token = await _authService.LoginAsync(request.Email, request.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                _logger.Error($"Error while Loging in user :{request.Email}, {ex.Message}");
                return Unauthorized(ex.Message);
            }
        }
    }
}
