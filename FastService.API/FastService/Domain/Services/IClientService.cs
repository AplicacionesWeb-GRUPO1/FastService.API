using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Services.Communication;

namespace FastService.API.FastService.Domain.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> ListAsync();
    Task<ClientResponse> GetByIdAsync(int id);
    Task<ClientResponse> SaveAsync(Client client);
    Task<ClientResponse> UpdateAsync(int id, Client client);
    Task<ClientResponse> DeleteAsync(int id);
}