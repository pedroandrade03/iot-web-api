using IOTWebAPI.Data;
using IOTWebAPI.Entities;
using IOTWebAPI.Repositories.Interfaces;

namespace IOTWebAPI.Repositories.Implementations;

public class GatewayRepository : IGatewayRepository
{
    private readonly DataContext _dataContext;
    
    public GatewayRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public List<Gateway> GetGateways()
    {
        return _dataContext.Gateways.ToList();
    }

    public Gateway? GetGateway(int gatewayId)
    {
        return _dataContext.Gateways.FirstOrDefault(g => g.GatewayID == gatewayId);
    }

    public bool GatewayExists(int gatewayId)
    {
        return _dataContext.Gateways.Any(g => g.GatewayID == gatewayId);
    }

    public bool CreateGateway(Gateway gateway)
    {
        _dataContext.Add(gateway);
        return Save();
    }

    public bool UpdateGateway(Gateway gateway)
    {
        _dataContext.Update(gateway);
        return Save();
    }
    
    public bool DeleteGateway(Gateway gateway)
    {
        _dataContext.Remove(gateway);
        return Save();
    }
    
    public bool Save()
    {
        return _dataContext.SaveChanges() > 0;
    }
}