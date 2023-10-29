using FastService.API.FastService.Domain.Models;
using FastService.API.Shared.Domain.Services.Communication;

namespace FastService.API.FastService.Domain.Services.Communication;

public class ContractResponse : BaseResponse<Contract>
{
    public ContractResponse(string message) : base(message)
    {
    }

    public ContractResponse(Contract resource) : base(resource)
    {
    }
}