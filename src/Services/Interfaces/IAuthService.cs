namespace reword.src.Services.Interfaces;
using reword.src.Dtos;
using reword.src.Entities;
public interface IAuthService
{
    Task<User?> RegisterAsync(RegisterDto registerDto);

    Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);
}
public interface IUserService
{
    Task<User?> GetUserByIdAsync(int id);

    Task<User?> GetUserByEmailAsync(string email);
}