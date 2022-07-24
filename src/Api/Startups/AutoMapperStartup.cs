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
                ConstructionMappingProfile();
                ClientMappingProfile();
                ConcreteTypeMappingProfile();
            }

            public void GeralMappingProfile() { }

            public void ConstructionMappingProfile()
            {
                CreateMap<Dtos.Construction.GetResponseDto, Models.Construction.GetResponseModel>();
                CreateMap<Models.Construction.PostRequestModel, Dtos.Construction.PostRequestDto>();
            }

            public void ClientMappingProfile()
            {
                CreateMap<Dtos.Client.GetResponseDto, Models.Client.GetResponseModel>();
                CreateMap<Models.Client.PostRequestModel, Dtos.Client.PostRequestDto>();
            }

            public void ConcreteTypeMappingProfile()
            {
                CreateMap<Dtos.ConcreteType.GetResponseDto, Models.ConcreteType.GetResponseModel>();
                CreateMap<Models.ConcreteType.PostRequestModel, Dtos.ConcreteType.PostRequestDto>();
            }
        }
    }
}
