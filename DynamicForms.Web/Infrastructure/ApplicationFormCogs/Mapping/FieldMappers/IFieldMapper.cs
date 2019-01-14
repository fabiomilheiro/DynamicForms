using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public interface IFieldMapper
    {
        void MapToApplication(Application application, FieldBase field);
        void MapToField(Application application, FieldBase field);
    }
}