using FastService.API.Security.Domain.Models;
using FastService.API.Security.Domain.Repositories;
using FastService.API.Shared.Persistence.Contexts;
using FastService.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastService.API.Security.Persistence.Repositories;

public class UserRepository :BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> FindByUsernameAsync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
    }

    public bool ExistsByUsername(string username)
    {
        return _context.Users.Any(x => x.UserName == username);
    }

    public User FindById(int id)
    {
        return _context.Users.Find(id);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }
}