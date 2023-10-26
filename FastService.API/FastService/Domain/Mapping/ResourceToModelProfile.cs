using AutoMapper;
using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Resources;

namespace FastService.API.Learning.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveClientResource, Client>();
        CreateMap<SavePublicationResource, Publication>();
    }
}