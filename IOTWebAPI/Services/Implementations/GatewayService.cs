using AutoMapper;
using IOTWebAPI.DTOs;
using IOTWebAPI.Entities;
using IOTWebAPI.Repositories.Interfaces;
using IOTWebAPI.Services.Interfaces;

namespace IOTWebAPI.Services.Implementations;

public class GatewayService : IGatewayService
{   
    private readonly IMapper _mapper;
    private readonly IGatewayRepository _gatewayRepository;

    public GatewayService(IGatewayRepository gatewayRepository, IMapper mapper)
    {
        _mapper = mapper;
        _gatewayRepository = gatewayRepository;
    }
    public List<GatewayDto> GetGateways()
    {
        return _mapper.Map<List<GatewayDto>>(_gatewayRepository.GetGateways());
    }

    public GatewayDto? GetGateway(int gatewayId)
    {
        if (_gatewayRepository.GatewayExists(gatewayId))
            return _mapper.Map<GatewayDto>(_gatewayRepository.GetGateway(gatewayId));
        return null;
    }

    public bool CreateGateway(CreateGatewayDto createGatewayDto)
    {
        var gateway = _mapper.Map<Gateway>(createGatewayDto);
        return _gatewayRepository.CreateGateway(gateway);
    }

    public bool UpdateGateway(UpdateGatewayDto updateGatewayDto, int gatewayId)
    {   
        var existingGateway = _gatewayRepository.GetGateway(gatewayId);
        if (existingGateway == null)
            return false;
        
        _mapper.Map(updateGatewayDto, existingGateway);
        
        return _gatewayRepository.UpdateGateway(existingGateway);
    }
    
    public bool DeleteGateway(int gatewayId)
    {
        var gateway = _gatewayRepository.GetGateway(gatewayId);
        if (gateway == null)
            return false;
        
        return _gatewayRepository.DeleteGateway(gateway);
    }
}