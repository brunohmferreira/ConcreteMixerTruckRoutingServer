﻿using ConcreteMixerTruckRoutingServer.Dtos.Client;
using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Client
{
    public interface IClientRepository : IRepositoryContext
    {
        Task<IEnumerable<ClientEntity>> GetClientsList();
        Task<ClientEntity> GetClientById(int clientId);
        Task<IEnumerable<ClientEntity>> GetClientByFilter(GetRequestDto filter);
        Task<int> InsertClient(PostRequestDto dto);
        Task<bool> UpdateClient(PutRequestDto dto);
    }
}
