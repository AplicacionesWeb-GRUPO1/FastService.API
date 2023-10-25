using FastService.API.FastService.Shared.Persistence.Contexts;
using LearningCenter.API.Learning.Domain.Repositories;

namespace FastService.API.FastService.Shared.Persistence.Repositories;

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