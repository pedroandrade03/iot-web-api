using IOTWebAPI.DTOs;

namespace IOTWebAPI.Services.Interfaces;

public interface IGatewayService
{
    List<GatewayDto> GetGateways();
    GatewayDto? GetGateway(int gatewayId);
    bool CreateGateway(CreateGatewayDto createGatewayDto);
    bool UpdateGateway(UpdateGatewayDto updateGatewayDto, int gatewayId);
    bool DeleteGateway(int gatewayId);
}