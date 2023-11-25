using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Repositories;
using FastService.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FastService.API.Shared.Persistence.Repositories;

public class ClientRepository : BaseRepository, IClientRepository
{
    public ClientRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Client>> ListAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task AddAsync(Client category)
    {
        await _context.Clients.AddAsync(category);
    }

    public async Task<Client> FindByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    
    public async Task<Client> FindByUserNameAsync(string username)
    {
        return await _context.Clients.FirstOrDefaultAsync(client => client.UserName == username);
    }


    public void Update(Client category)
    {
        _context.Clients.Update(category);
    }

    public void Remove(Client category)
    {
        _context.Clients.Remove(category);
    }
}