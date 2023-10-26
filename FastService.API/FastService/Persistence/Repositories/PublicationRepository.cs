using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Repositories;
using FastService.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FastService.API.Shared.Persistence.Repositories;

public class PublicationRepository : BaseRepository, IPublicationRepository
{
    public PublicationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Publication>> ListAsync()
    {
        return await _context.Publications
            .Include(p => p.Client)
            .ToListAsync();
    }

    public async Task AddAsync(Publication publication)
    {
        await _context.Publications.AddAsync(publication);
    }

    public async Task<Publication> FindByIdAsync(int publicationId)
    {
        return await _context.Publications
            .Include(p => p.Client)
            .FirstOrDefaultAsync(p => p.Id == publicationId);
        
    }

    public async Task<Publication> FindByTitleAsync(string title)
    {
        return await _context.Publications
            .Include(p => p.Client)
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task<IEnumerable<Publication>> FindByClientIdAsync(int clientId)
    {
        return await _context.Publications
            .Where(p => p.ClientId == clientId)
            .Include(p => p.Client)
            .ToListAsync();
    }

    public void Update(Publication publication)
    {
        _context.Publications.Update(publication);
    }

    public void Remove(Publication publication)
    {
        _context.Publications.Remove(publication);
    }
}