using FastService.API.FastService.Shared.Persistence.Contexts;

namespace FastService.API.FastService.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}