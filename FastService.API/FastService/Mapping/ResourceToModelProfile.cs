using AutoMapper;
using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Resources;

namespace FastService.API.FastService.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveClientResource, Client>();
        CreateMap<SavePublicationResource, Publication>();

        CreateMap<SaveExpertResource, Expert>();
        CreateMap<SaveContractResource, Contract>();
    }
}