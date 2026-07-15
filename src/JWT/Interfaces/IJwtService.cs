namespace reword.src.JWT.Interfaces;
using reword.src.Entities;


    public interface IJwtService
    {
        string GenerateToken(User user);
    }
