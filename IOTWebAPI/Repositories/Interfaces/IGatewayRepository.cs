using IOTWebAPI.Entities;

namespace IOTWebAPI.Repositories.Interfaces;

public interface IGatewayRepository
{
    List<Gateway> GetGateways();
    Gateway? GetGateway(int gatewayId);
    bool GatewayExists(int gatewayId);
    bool CreateGateway(Gateway gateway);
    bool UpdateGateway(Gateway gateway);
    bool DeleteGateway(Gateway gateway);
    bool Save();
}