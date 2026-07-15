namespace reword.src.Services;
using reword.src.Services.Interfaces;
using reword.src.Dtos;
using reword.src.Entities;
using reword.src.Repositories.Interfaces;
using BCrypt.Net;
using reword.src.JWT.Interfaces;
public class AuthService :  IAuthService

{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public AuthService(IUserRepository userRepository , IJwtService jwtService)
    { 
        _userRepository = userRepository;
        _jwtService = jwtService;
    }
  public async Task<User?> RegisterAsync(RegisterDto registerDto)
    {
        
          var UserExist = await _userRepository.GetByEmailAsync(registerDto.Email);
        if (UserExist != null)
        {
            return null; // User already exists
        }
        
    var hash = BCrypt.HashPassword(registerDto.Password);
        // Create a new User entity from the RegisterDto
         Random random = new Random();
        string randomColor = random.Next(0x1000000).ToString("X6");
        string randomSeed = Guid.NewGuid().ToString();
        string avatarUrl = $"https://api.dicebear.com/9.x/adventurer-neutral/svg?seed={randomSeed}&backgroundColor={randomColor}";
        var user = new User
        {
            Name = registerDto.Name,
            Email = registerDto.Email,
            Password = hash,
            Avatar = avatarUrl,
            CreatedAt = registerDto.CreatedAt,
            NativeLanguage = registerDto.NativeLanguage,
            LearningLanguage = registerDto.LearningLanguage
        };

      var saveUser = await _userRepository.CreateAsync(user);

        return saveUser; // Return the created user (or null if creation failed)
    }
public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
{
    var user = await _userRepository.GetByEmailAsync(loginDto.Email);

    if (user == null)
    {
        return null;
    }

    var validPassword = BCrypt.Verify(loginDto.Password, user.Password);
    Console.WriteLine($"Resultado BCrypt: {validPassword}");
    if (!validPassword)
{
    throw new Exception("Correo o contraseña incorrectos");
}

    var token = _jwtService.GenerateToken(user);

    return new AuthResponseDto
    {
       Token = token,
    User = new UserDto
    {
        Id = user.Id,
        Name = user.Name,
        Avatar = user.Avatar,
        Email = user.Email
    }
    };
}
}