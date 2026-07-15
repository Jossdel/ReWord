namespace reword.src.Controllers;

using reword.src.Services.Interfaces;
using reword.src.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
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
            user.Avatar,
            user.CreatedAt,
           
            user.NativeLanguage,
            user.LearningLanguage
        });
    }
      [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
              
   try
   {
        var user = await _authService.LoginAsync(loginDto);
        return Ok(user);
  }
   catch (Exception ex )
   {
   return Conflict(new{
                message = ex.Message
            });
   };

    }
}