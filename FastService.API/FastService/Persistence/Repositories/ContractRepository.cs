using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Repositories;
using FastService.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FastService.API.Shared.Persistence.Repositories;

public class ContractRepository : BaseRepository, IContractRepository
{
    public ContractRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Contract>> ListAsync()
    {
        return await _context.Contracts
            .Include(p => p.Expert)
            .ToListAsync();
    }

    public async Task AddAsync(Contract contract)
    {
        await _context.Contracts.AddAsync(contract);
    }

    public async Task<Contract> FindByIdAsync(int contractId)
    {
        return await _context.Contracts
            .Include(p => p.Expert)
            .FirstOrDefaultAsync(p => p.Id == contractId);
    }

    public async Task<Contract> FindByPublicationIdAsync(int publicationId)
    {
        return await _context.Contracts
            .Include(p => p.Expert)
            .FirstOrDefaultAsync(p => p.PublicationId == publicationId);
    }

    public async Task<IEnumerable<Contract>> FindByExpertIdAsync(int expertId)
    {
        return await _context.Contracts
            .Where(p => p.ExpertId == expertId)
            .Include(p => p.Expert)
            .ToListAsync();
    }

    public void Update(Contract contract)
    {
        _context.Contracts.Update(contract);
    }

    public void Remove(Contract contract)
    {
        _context.Contracts.Remove(contract);
    }
}