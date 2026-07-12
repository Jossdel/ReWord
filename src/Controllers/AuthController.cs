namespace reword.src.Controllers;

using reword.src.Services;
using reword.src.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var user = await _authService.RegisterAsync(registerDto);


if (user == null)
{
    return Conflict("Ya existe un usuario con ese correo.");
}

        return Ok(new
        {
            user.Id,
            user.Name,
            user.Email,
            user.CreatedAt,
     
            user.NativeLanguage,
            user.LearningLanguage
        });
    }
      [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _authService.LoginAsync(loginDto);

        if (user == null)
        {
            return Unauthorized(new
            {
                message = "Correo o contraseña incorrectos."
            });
        }

        return Ok(new
        {
            message = "Inicio de sesión exitoso.",
            user = new
            {
                user.Id,
                user.Name,
                user.Email,
                user.NativeLanguage,
                user.LearningLanguage,
                user.CreatedAt
            }
        });
    }
}