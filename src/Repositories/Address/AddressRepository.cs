using ConcreteMixerTruckRoutingServer.Dtos.Address;
using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Address;
using Dapper;

namespace ConcreteMixerTruckRoutingServer.Repositories.Address
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public async Task<AddressEntity> GetAddressByConstructionId(int constructionId)
        {
            return await Context.Connection.QuerySingleOrDefaultAsync<AddressEntity>(
                sql: $@"
                    SELECT 
                        A.AddressId,
                        A.Street,
                        A.Number,
                        A.NoNumber,
                        A.Complement,
                        A.Neighborhood,
                        A.ZipCode,
                        A.City,
                        A.State,
                        A.Country,
                        A.Latitude,
                        A.Longitude,
                        A.ChangeDatetime
                    FROM Address A 
                    WHERE A.ConstructionId = @ConstructionId",
                param: new { ConstructionId = constructionId },
                transaction: Context.Transaction);
        }

        public async Task<int> InsertAddress(PostRequestDto dto, int constructionId)
        {
            return await Context.Connection.QuerySingleOrDefaultAsync<int>(
                sql: $@"
                    INSERT INTO Address (
                        ConstructionId,
                        Street,
                        Number,
                        NoNumber,
                        Complement,
                        Neighborhood,
                        ZipCode,
                        City,
                        State,
                        Country,
                        Latitude,
                        Longitude,
                        ChangeDatetime
                    ) VALUES (
                        @ConstructionId,
                        @Street,
                        @Number,
                        @NoNumber,
                        @Complement,
                        @Neighborhood,
                        @ZipCode,
                        @City,
                        @State,
                        @Country,
                        @Latitude,
                        @Longitude,
                        GETDATE()
                    )
                    SELECT SCOPE_IDENTITY()",
                param: new
                {
                    ConstructionId = constructionId,
                    Street = dto.Street,
                    Number = dto.Number,
                    NoNumber = dto.NoNumber,
                    Complement = dto.Complement,
                    Neighborhood = dto.Neighborhood,
                    ZipCode = dto.ZipCode,
                    City = dto.City,
                    State = dto.State,
                    Country = dto.Country,
                    Latitude = dto.Latitude,
                    Longitude = dto.Longitude
                },
                transaction: Context.Transaction);
        }

        public async Task<bool> UpdateAddress(PutRequestDto dto, int constructionId)
        {
            var amountOfAffectedRows = await Context.Connection.ExecuteAsync(
                sql: $@"
                    UPDATE Address 
                    SET ConstructionId = @ConstructionId,
                        Street = @Street,
                        Number = @Number,
                        NoNumber = @NoNumber,
                        Complement = @Complement,
                        Neighborhood = @Neighborhood,
                        ZipCode = @ZipCode,
                        City = @City,
                        State = @State,
                        Country = @Country,
                        Latitude = @Latitude,
                        Longitude = @Longitude
                    WHERE AddressId = @AddressId",
                param: new
                {
                    AddressId = dto.AddressId,
                    ConstructionId = constructionId,
                    Street = dto.Street,
                    Number = dto.Number,
                    NoNumber = dto.NoNumber,
                    Complement = dto.Complement,
                    Neighborhood = dto.Neighborhood,
                    ZipCode = dto.ZipCode,
                    City = dto.City,
                    State = dto.State,
                    Country = dto.Country,
                    Latitude = dto.Latitude,
                    Longitude = dto.Longitude
                },
                transaction: Context.Transaction);

            return amountOfAffectedRows > 0;
        }

        public async Task<bool> DeleteAddress(int constructionId)
        {
            var amountOfAffectedRows = await Context.Connection.ExecuteAsync(
                sql: $@"
                    DELETE FROM Address
                    WHERE ConstructionId = @ConstructionId",
                param: new { ConstructionId = constructionId },
                transaction: Context.Transaction);

            return amountOfAffectedRows > 0;
        }
    }
}
