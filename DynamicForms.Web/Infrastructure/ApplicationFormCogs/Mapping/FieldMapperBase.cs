using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping
{
    public abstract class FieldMapperBase<TField> : IFieldMapper where TField : FieldBase
    {
        public void MapToApplication(Application application, FieldBase field)
        {
            MapToApplicationUsingMappingExpressions(application, (TField) field);
            MapToApplication(application, (TField)field);
        }

        public void MapToField(Application application, FieldBase field)
        {
            MapToFieldUsingMappingExpressions(application, (TField)field);
            MapToField(application, (TField)field);
        }

        protected virtual void MapToApplication(Application application, TField field)
        {
        }

        protected virtual void MapToField(Application application, TField field)
        {
        }

        protected virtual IEnumerable<Mapping<TField>> Mappings { get; }

        private void MapToApplicationUsingMappingExpressions(Application application, FieldBase field)
        {
            if (Mappings == null)
            {
                return;
            }

            var f = (TField)field;

            foreach (var mapping in Mappings)
            {
                var applicationExpression = mapping.ApplicationExpression;
                var fieldValue = mapping.FieldExpression.Compile()(f);

                application.SetPropertyValue(applicationExpression, fieldValue);
            }
        }

        private void MapToFieldUsingMappingExpressions(Application application, FieldBase field)
        {
            if (Mappings == null)
            {
                return;
            }

            var f = (TField) field;

            foreach (var mapping in Mappings)
            {
                var fieldExpression = mapping.FieldExpression;
                var applicationValue = mapping.ApplicationExpression.Compile()(application);

                f.SetPropertyValue(fieldExpression, applicationValue);
            }
        }
    }

    public class Mapping<TField> where TField : FieldBase
    {
        public Mapping(Expression<Func<TField, object>> fieldExpression, Expression<Func<Application, object>> applicationExpression)
        {
            FieldExpression = fieldExpression;
            ApplicationExpression = applicationExpression;
        }

        public Expression<Func<Application, object>> ApplicationExpression { get; set; }
        public Expression<Func<TField, object>> FieldExpression { get; set; }
    }
}