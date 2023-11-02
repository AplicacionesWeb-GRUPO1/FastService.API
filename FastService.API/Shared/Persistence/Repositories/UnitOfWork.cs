using FastService.API.Shared.Persistence.Contexts;
using FastService.API.FastService.Domain.Repositories;

namespace FastService.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync(); 
    }
}