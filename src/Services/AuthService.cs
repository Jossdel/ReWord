namespace reword.src.Services;
using reword.src.Services.Interfaces;
using reword.src.Dtos;
using reword.src.Entities;
using reword.src.Repositories;
using BCrypt.Net;
public class AuthService :  IAuthService

{
    private readonly UserRepository _userRepository;

    public AuthService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
  public async Task<User?> RegisterAsync(RegisterDto registerDto)
    {
        
          var UserExist = await _userRepository.GetByEmailAsync(registerDto.Email);
        if (UserExist != null)
        {
            return null; // User already exists
        }
    var hash = BCrypt.HashPassword(registerDto.PasswordHash);
        // Create a new User entity from the RegisterDto
        var user = new User
        {
            Name = registerDto.Name,
            Email = registerDto.Email,
            PasswordHash = hash,
            CreatedAt = registerDto.CreatedAt,
            NativeLanguage = registerDto.NativeLanguage,
            LearningLanguage = registerDto.LearningLanguage
        };

      var saveUser = await _userRepository.CreateAsync(user);

        return saveUser; // Return the created user (or null if creation failed)
    }
   public async Task<User?> LoginAsync(LoginDto loginDto)
{
    var user = await _userRepository.GetByEmailAsync(loginDto.Email);

    if (user == null)
    {
        return null;
    }

    bool validPassword = BCrypt.Verify(loginDto.PasswordHash, user.PasswordHash);

    if (!validPassword)
    {
        return null;
    }

    return user;
}
}