using FastService.API.FastService.Domain.Models;

namespace FastService.API.FastService.Domain.Repositories;

public interface IPublicationRepository
{
    Task<IEnumerable<Publication>> ListAsync();
    Task AddAsync(Publication client);
    Task<Publication> FindByIdAsync(int clientId);
    Task<Publication> FindByTitleAsync(string title);
    Task<IEnumerable<Publication>> FindByClientIdAsync(int clientId);
    void Update(Publication client);
    void Remove(Publication client);
}