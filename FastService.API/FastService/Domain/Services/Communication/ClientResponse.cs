using FastService.API.FastService.Domain.Models;
using FastService.API.Shared.Domain.Services.Communication;

namespace FastService.API.FastService.Domain.Services.Communication;

public class ClientResponse : BaseResponse<Client>
{
    public ClientResponse(string message) : base(message)
    {
    }

    public ClientResponse(Client resource) : base(resource)
    {
    }
}