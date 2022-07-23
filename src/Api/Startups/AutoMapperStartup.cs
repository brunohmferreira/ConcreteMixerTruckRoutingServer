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
            }

            public void GeralMappingProfile() { }

            public void ConstructionMappingProfile()
            {
                CreateMap<Dtos.Constrution.GetResponseDto, Models.Construction.GetResponseModel>();
            }
        }
    }
}
