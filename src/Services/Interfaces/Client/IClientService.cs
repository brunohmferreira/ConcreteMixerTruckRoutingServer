﻿using ConcreteMixerTruckRoutingServer.Dtos.Client;

namespace ConcreteMixerTruckRoutingServer.Services.Interfaces.Client
{
    public interface IClientService
    {
        Task<List<GetResponseDto>> GetClientsList();
        Task<GetResponseDto> GetClientById(int clientId);
        Task<int> InsertClient(PostRequestDto dto);
        Task<bool> UpdateClient(PutRequestDto dto);
    }
}
