using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Services.Communication;

namespace FastService.API.FastService.Domain.Services;

public interface IExpertService
{
    Task<IEnumerable<Expert>> ListAsync();
    Task<ExpertResponse> GetByIdAsync(int id);
    Task<ExpertResponse> SaveAsync(Expert expert);
    Task<ExpertResponse> UpdateAsync(int id, Expert expert);
    Task<ExpertResponse> DeleteAsync(int id);
}