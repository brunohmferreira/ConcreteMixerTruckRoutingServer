using AutoMapper;

namespace ConcreteMixerTruckRoutingServer.Api.Startups
{
    public static class AutoMapperStartup
    {
        public static void AddCustomAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullDestinationValues = true;
                mc.AllowNullCollections = true;
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                GeralMappingProfile();
                AddressMappingProfile();
                ConstructionMappingProfile();
                ClientMappingProfile();
                ConcreteTypeMappingProfile();
                ConcreteMixerTruckMappingProfile();
            }

            public void GeralMappingProfile() { }

            public void AddressMappingProfile()
            {
                CreateMap<Dtos.Address.GetResponseDto, Models.Address.GetResponseModel>();
                CreateMap<Models.Address.PostRequestModel, Dtos.Address.PostRequestDto>();
                CreateMap<Models.Address.PutRequestModel, Dtos.Address.PutRequestDto>();
            }

            public void ConstructionMappingProfile()
            {
                CreateMap<Dtos.Construction.GetResponseDto, Models.Construction.GetResponseModel>();
                CreateMap<Models.Construction.PostRequestModel, Dtos.Construction.PostRequestDto>();
                CreateMap<Models.Construction.PutRequestModel, Dtos.Construction.PutRequestDto>();
            }

            public void ClientMappingProfile()
            {
                CreateMap<Dtos.Client.GetResponseDto, Models.Client.GetResponseModel>();
                CreateMap<Models.Client.PostRequestModel, Dtos.Client.PostRequestDto>();
                CreateMap<Models.Client.PutRequestModel, Dtos.Client.PutRequestDto>();
            }

            public void ConcreteTypeMappingProfile()
            {
                CreateMap<Dtos.ConcreteType.GetResponseDto, Models.ConcreteType.GetResponseModel>();
                CreateMap<Models.ConcreteType.PostRequestModel, Dtos.ConcreteType.PostRequestDto>();
                CreateMap<Models.ConcreteType.PutRequestModel, Dtos.ConcreteType.PutRequestDto>();
            }
            
            public void ConcreteMixerTruckMappingProfile()
            {
                CreateMap<Dtos.ConcreteMixerTruck.GetResponseDto, Models.ConcreteMixerTruck.GetResponseModel>();
            }
        }
    }
}
