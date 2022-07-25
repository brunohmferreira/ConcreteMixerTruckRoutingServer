using ConcreteMixerTruckRoutingServer.Dtos.Client;
using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Client;
using Dapper;

namespace ConcreteMixerTruckRoutingServer.Repositories.Client
{
    public class ClientRepository : RepositoryBase, IClientRepository
    {
        public async Task<ClientEntity> GetClientById(int clientId)
        {
            return await Context.Connection.QuerySingleOrDefaultAsync<ClientEntity>(
                sql: $@"
                    SELECT 
                        C.ClientId,
                        C.Name,
                        C.ChangeDatetime
                    FROM Client C 
                    WHERE C.ClientId = @ClientId",
                param: new { ClientId = clientId },
                transaction: Context.Transaction);
        }

        public async Task<IEnumerable<ClientEntity>> GetClientByFilter(GetRequestDto filter)
        {
            return await Context.Connection.QueryAsync<ClientEntity>(
                sql: $@"
                    SELECT 
                        C.ClientId,
                        C.Name,
                        C.ChangeDatetime
                    FROM Client C 
                    WHERE C.ClientId <> 0
                        {(filter.Name != null ?
                        " AND C.Name = @Name" : "")}",
                param: filter,
                transaction: Context.Transaction);
        }

        public async Task<int> InsertClient(PostRequestDto dto)
        {
            return await Context.Connection.QuerySingleOrDefaultAsync<int>(
                sql: $@"
                    INSERT INTO Client (
                        Name,
                        ChangeDatetime
                    ) VALUES (
                        @Name,
                        GETDATE()
                    )
                    SELECT SCOPE_IDENTITY()",
                param: dto,
                transaction: Context.Transaction);
        }

        public async Task<bool> UpdateClient(PutRequestDto dto)
        {
            var amountOfAffectedRows = await Context.Connection.ExecuteAsync(
                sql: $@"
                    UPDATE Client 
                    SET Name = @Name
                    WHERE ClientId = @ClientId",
                param: dto,
                transaction: Context.Transaction);

            return amountOfAffectedRows > 0;
        }
    }
}
