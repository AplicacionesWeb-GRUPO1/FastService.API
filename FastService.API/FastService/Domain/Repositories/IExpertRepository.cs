using FastService.API.FastService.Domain.Models;

namespace FastService.API.FastService.Domain.Repositories;

public interface IExpertRepository
{
    Task<IEnumerable<Expert>> ListAsync();
    Task AddAsync(Expert expert);
    Task<Expert> FindByIdAsync(int id);
    Task<Expert> FindByUserNameAsync(string username);
    void Update(Expert expert);
    void Remove(Expert expert);

}