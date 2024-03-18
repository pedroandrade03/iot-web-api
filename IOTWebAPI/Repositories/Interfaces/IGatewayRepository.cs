using IOTWebAPI.Entities;
using System.Collections.Generic;

namespace IOTWebAPI.Repositories.Interfaces
{
    public interface IGatewayRepository
    {
        List<Gateway> GetGateways();
        Gateway? GetGateway(int gatewayId);
        bool GatewayExists(int gatewayId);
        bool CreateGateway(Gateway gateway);
        bool UpdateGateway(Gateway gateway);
        bool DeleteGateway(Gateway gateway);
        bool Save();

        // Novos métodos para obter gateways com suas configurações
        List<Gateway> GetGatewaysWithConfiguration();
        Gateway GetGatewayWithConfiguration(int gatewayId);
    }
}
