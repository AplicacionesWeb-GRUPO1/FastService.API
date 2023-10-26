using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Services.Communication;

namespace FastService.API.FastService.Domain.Services;

public interface IPublicationService
{
    Task<IEnumerable<Publication>> ListAsync();
    Task<IEnumerable<Publication>> ListByClientIdAsync(int clientId);
    Task<PublicationResponse> SaveAsync(Publication publication);
    Task<PublicationResponse> UpdateAsync(int publicationId, Publication publication);
    Task<PublicationResponse> DeleteAsync(int publicationId);
}