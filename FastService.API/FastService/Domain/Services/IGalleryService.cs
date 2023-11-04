using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Services.Communication;

namespace FastService.API.FastService.Domain.Services;

public interface IGalleryService
{
    Task<IEnumerable<Gallery>> ListAsync();
    Task<IEnumerable<Gallery>> ListByExpertIdAsync(int expertId);
    Task<GalleryResponse> SaveAsync(Gallery Gallery);
    Task<GalleryResponse> UpdateAsync(int galleryId, Gallery gallery);
    Task<GalleryResponse> DeleteAsync(int galleryId);
}