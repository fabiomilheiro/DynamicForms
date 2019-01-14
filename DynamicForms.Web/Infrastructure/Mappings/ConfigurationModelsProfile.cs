using AutoMapper;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.Mappings
{
    public class ConfigurationModelsProfile : Profile
    {
        public ConfigurationModelsProfile()
        {
            CreateMap<Step, Step>();
            CreateMap<Section, Section>();
        }
    }
}