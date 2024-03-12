using AutoMapper;
using IOTWebAPI.DTOs;
using IOTWebAPI.Entities;

namespace IOTWebAPI.Helpers;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Gateway, GatewayDto>();
        CreateMap<CreateGatewayDto, Gateway>();
        CreateMap<UpdateGatewayDto, Gateway>();
    }
}