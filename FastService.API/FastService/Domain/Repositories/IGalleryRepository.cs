using FastService.API.FastService.Domain.Models;

namespace FastService.API.FastService.Domain.Repositories;

public interface IGalleryRepository
{
    Task<IEnumerable<Gallery>> ListAsync();
    Task AddAsync(Gallery gallery);
    Task<Gallery> FindByIdAsync(int galleryId);
    Task<IEnumerable<Gallery>> FindByExpertIdAsync(int expertId);
    void Update(Gallery gallery);
    void Remove(Gallery gallery);
}