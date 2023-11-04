using FastService.API.FastService.Domain.Models;
using FastService.API.Shared.Domain.Services.Communication;

namespace FastService.API.FastService.Domain.Services.Communication;

public class GalleryResponse : BaseResponse<Gallery>
{
    public GalleryResponse(string message) : base(message)
    {
    }

    public GalleryResponse(Gallery resource) : base(resource)
    {
    }
}