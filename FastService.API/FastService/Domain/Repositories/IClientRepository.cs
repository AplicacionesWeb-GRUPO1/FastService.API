using FastService.API.FastService.Domain.Models;

namespace FastService.API.FastService.Domain.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> ListAsync();
    Task AddAsync(Client client);
    Task<Client> FindByIdAsync(int id);
    void Update(Client client);
    void Remove(Client client);

}