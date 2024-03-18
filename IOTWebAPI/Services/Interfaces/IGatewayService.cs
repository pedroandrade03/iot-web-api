using IOTWebAPI.DTOs;
using System.Collections.Generic;

namespace IOTWebAPI.Services.Interfaces
{
    public interface IGatewayService
    {
        List<GatewayWithConfigurationDto> GetGatewaysWithConfiguration();
        GatewayWithConfigurationDto GetGatewayWithConfiguration(int gatewayId);
        bool CreateGateway(CreateGatewayDto createGatewayDto);
        bool UpdateGateway(UpdateGatewayDto updateGatewayDto, int gatewayId);
        bool DeleteGateway(int gatewayId);
    }
}
