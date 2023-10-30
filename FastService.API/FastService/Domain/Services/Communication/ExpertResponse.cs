using FastService.API.FastService.Domain.Models;
using FastService.API.Shared.Domain.Services.Communication;

namespace FastService.API.FastService.Domain.Services.Communication;

public class ExpertResponse : BaseResponse<Expert>
{
    public ExpertResponse(string message) : base(message)
    {
    }

    public ExpertResponse(Expert resource) : base(resource)
    {
    }
}