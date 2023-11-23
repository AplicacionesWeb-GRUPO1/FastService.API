using AutoMapper;
using FastService.API.Security.Domain.Models;
using FastService.API.Security.Domain.Services.Communication;
using FastService.API.Security.Resources;

namespace FastService.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}