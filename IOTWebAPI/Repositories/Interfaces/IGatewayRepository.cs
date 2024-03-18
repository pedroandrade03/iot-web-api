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

        // Novos m�todos para obter gateways com suas configura��es
        List<Gateway> GetGatewaysWithConfiguration();
        Gateway GetGatewayWithConfiguration(int gatewayId);
    }
}
