using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Repositories;
using FastService.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FastService.API.Shared.Persistence.Repositories;

public class GalleryRepository : BaseRepository, IGalleryRepository
{
    public GalleryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Gallery>> ListAsync()
    {
        return await _context.Galleries
            .Include(p => p.Expert)
            .ToListAsync();
    }

    public async Task AddAsync(Gallery gallery)
    {
        await _context.Galleries.AddAsync(gallery);
    }

    public async Task<Gallery> FindByIdAsync(int GalleryId)
    {
        return await _context.Galleries
            .Include(p => p.Expert)
            .FirstOrDefaultAsync(p => p.Id == GalleryId);
    }

    public async Task<IEnumerable<Gallery>> FindByExpertIdAsync(int clientId)
    {
        return await _context.Galleries
            .Where(p => p.ExpertId == clientId)
            .Include(p => p.Expert)
            .ToListAsync();
    }

    public void Update(Gallery Gallery)
    {
        _context.Galleries.Update(Gallery);
    }

    public void Remove(Gallery Gallery)
    {
        _context.Galleries.Remove(Gallery);
    }
}