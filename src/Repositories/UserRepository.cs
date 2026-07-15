namespace reword.src.Repositories;
using Microsoft.EntityFrameworkCore;
using reword.src.Data;
using reword.src.Entities;
using reword.src.Repositories.Interfaces;
public class UserRepository : IUserRepository
{
 
private readonly AppDbContext _context;
public UserRepository(AppDbContext context)
    {
        _context = context;
    }

public async Task<User?> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;

    }
public async Task<User?> GetByEmailAsync (string email)
    {
        
       return  await _context.Users.SingleOrDefaultAsync(f => f.Email == email);   
    }
public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(f => f.Id == id);
    }

    }



