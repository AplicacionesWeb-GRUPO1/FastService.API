using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Services.Communication;

namespace FastService.API.FastService.Domain.Services;

public interface IContractService
{
    Task<IEnumerable<Contract>> ListAsync();
    Task<IEnumerable<Contract>> ListByExpertIdAsync(int expertId);
    Task<ContractResponse> SaveAsync(Contract contract);
    Task<ContractResponse> UpdateAsync(int contractId, Contract contract);
    Task<ContractResponse> DeleteAsync(int contractId);
}