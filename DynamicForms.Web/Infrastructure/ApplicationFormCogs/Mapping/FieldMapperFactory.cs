using System;
using System.Linq;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping
{
    public interface IFieldMapperFactory
    {
        IFieldMapper Get(Type fieldType);
    }

    public class FieldMapperFactory : IFieldMapperFactory
    {
        private readonly IFieldMapper[] fieldMappers;

        public FieldMapperFactory(IFieldMapper[] fieldMappers)
        {
            this.fieldMappers = fieldMappers;
        }

        public IFieldMapper Get(Type fieldType)
        {
            var fieldMapperTypeName = fieldType.Name + "Mapper";

            var fieldMapper = fieldMappers.SingleOrDefault(t => t.GetType().Name == fieldMapperTypeName);

            if (fieldMapper == null)
            {
                throw new NotSupportedException($"There is no field mapper named '{fieldMapperTypeName}'. Be sure to suffix the field class with 'FieldMapper'.");
            }

            return fieldMapper;
        }
    }
}