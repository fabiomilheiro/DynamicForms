using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping
{
    public interface IFieldMappingOrchestrator
    {
        void MapToFields(Application application, FieldBase[] fields);
        void MapToApplication(Application application, FieldBase[] fields);
    }

    public class FieldMappingOrchestrator : IFieldMappingOrchestrator
    {
        private readonly IFieldMapperFactory fieldMapperFactory;

        public FieldMappingOrchestrator(IFieldMapperFactory fieldMapperFactory)
        {
            this.fieldMapperFactory = fieldMapperFactory;
        }

        public void MapToFields(Application application, FieldBase[] fields)
        {
            foreach (var field in fields)
            {
                var fieldMapper = fieldMapperFactory.Get(field.GetType());

                fieldMapper.MapToField(application, field);
            }
        }

        public void MapToApplication(Application application, FieldBase[] fields)
        {
            foreach (var field in fields)
            {
                var fieldMapper = fieldMapperFactory.Get(field.GetType());

                fieldMapper.MapToApplication(application, field);
            }
        }
    }
}