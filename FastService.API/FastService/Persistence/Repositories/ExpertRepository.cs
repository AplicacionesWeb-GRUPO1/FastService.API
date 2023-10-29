using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Repositories;
using FastService.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FastService.API.Shared.Persistence.Repositories;

public class ExpertRepository : BaseRepository, IExpertRepository
{
    public ExpertRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Expert>> ListAsync()
    {
        return await _context.Experts.ToListAsync();
    }

    public async Task AddAsync(Expert expert)
    {
        await _context.Experts.AddAsync(expert);
    }

    public async Task<Expert> FindByIdAsync(int id)
    {
        return await _context.Experts.FindAsync(id);
    }

    public void Update(Expert expert)
    {
        _context.Experts.Update(expert);
    }

    public void Remove(Expert expert)
    {
        _context.Experts.Remove(expert);
    }
}