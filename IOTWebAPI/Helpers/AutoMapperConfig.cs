using AutoMapper;
using IOTWebAPI.DTOs;
using IOTWebAPI.Entities;

namespace IOTWebAPI.Helpers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Mapeamentos para Gateway
            CreateMap<Gateway, GatewayDto>();
            CreateMap<CreateGatewayDto, Gateway>();
            CreateMap<UpdateGatewayDto, Gateway>();

            // Mapeamentos para Configuration
            CreateMap<Configuration, ConfigurationDto>();
            CreateMap<ConfigurationDto, Configuration>();

            // Mapeamento para GatewayWithConfigurationDto
            CreateMap<Gateway, GatewayWithConfigurationDto>()
                .ForMember(dest => dest.Configuration, opt => opt.MapFrom(src => src.Configuration));
        }
    }
}
