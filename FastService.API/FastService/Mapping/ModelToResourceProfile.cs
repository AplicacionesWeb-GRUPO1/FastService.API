using AutoMapper;
using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Resources;

namespace FastService.API.FastService.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Client, ClientResource>();
        CreateMap<Publication, PublicationResource>();
    }
}