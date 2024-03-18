using AutoMapper;
using IOTWebAPI.DTOs;
using IOTWebAPI.Entities;
using IOTWebAPI.Repositories.Interfaces;
using IOTWebAPI.Services.Interfaces;
using System.Collections.Generic;

namespace IOTWebAPI.Services.Implementations
{
    public class GatewayService : IGatewayService
    {
        private readonly IMapper _mapper;
        private readonly IGatewayRepository _gatewayRepository;

        public GatewayService(IGatewayRepository gatewayRepository, IMapper mapper)
        {
            _gatewayRepository = gatewayRepository;
            _mapper = mapper;
        }

        public List<GatewayDto> GetGateways()
        {
            var gateways = _gatewayRepository.GetGateways();
            return _mapper.Map<List<GatewayDto>>(gateways);
        }

        public GatewayDto? GetGateway(int gatewayId)
        {
            var gateway = _gatewayRepository.GetGateway(gatewayId);
            return _mapper.Map<GatewayDto>(gateway);
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

        // Implementação dos novos métodos para obter gateways com suas configurações
        public List<GatewayWithConfigurationDto> GetGatewaysWithConfiguration()
        {
            var gateways = _gatewayRepository.GetGatewaysWithConfiguration();
            return _mapper.Map<List<GatewayWithConfigurationDto>>(gateways);
        }

        public GatewayWithConfigurationDto GetGatewayWithConfiguration(int gatewayId)
        {
            var gateway = _gatewayRepository.GetGatewayWithConfiguration(gatewayId);
            return _mapper.Map<GatewayWithConfigurationDto>(gateway);
        }
    }
}
