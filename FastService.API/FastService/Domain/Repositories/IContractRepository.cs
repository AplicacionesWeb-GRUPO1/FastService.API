using FastService.API.FastService.Domain.Models;

namespace FastService.API.FastService.Domain.Repositories;

public interface IContractRepository
{
    Task<IEnumerable<Contract>> ListAsync();
    Task<Contract> FindByIdAsync(int contractId);
    Task<Contract> FindByPublicationIdAsync(int publicationId);
    Task<IEnumerable<Contract>> FindByExpertIdAsync(int ExpertId);
    
    Task AddAsync(Contract contract);
    void Update(Contract contract);
    void Remove(Contract contract);
}