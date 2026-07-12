using reword.src.Entities;

namespace reword.src.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> CreateAsync(User user);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(int id);
}