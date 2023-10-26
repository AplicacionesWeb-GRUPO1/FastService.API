using FastService.API.FastService.Domain.Models;
using FastService.API.Shared.Domain.Services.Communication;

namespace FastService.API.FastService.Domain.Services.Communication;

public class PublicationResponse : BaseResponse<Publication>
{
    public PublicationResponse(string message) : base(message)
    {
    }

    public PublicationResponse(Publication resource) : base(resource)
    {
    }
}