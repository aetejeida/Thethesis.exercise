using AutoMapper;
using thesis_exercise.services.Mapping.Profiles;

namespace thesis_exercise.services.Mapping
{
    public static class MappingProfiles
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config) 
        {
            config.AddProfile<ComputerProfile>();
        }
    }
}
