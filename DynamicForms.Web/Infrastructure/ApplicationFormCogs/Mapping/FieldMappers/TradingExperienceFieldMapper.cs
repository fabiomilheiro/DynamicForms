using System.Collections.Generic;
using System.Linq;
using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class TradingExperienceFieldMapper : FieldMapperBase<TradingExperienceField>
    {
        protected override IEnumerable<Mapping<TradingExperienceField>> Mappings => new Mapping<TradingExperienceField>[]
        {
        };

        protected override void MapToApplication(Application application, TradingExperienceField field)
        {
            var tradingExperienceAnswers = application.Applicants[0].TradingExperiences;

            var answer = GetAnswer(field, tradingExperienceAnswers);
            if (answer != null)
            {
                answer.Value = field.Value;
                return;
            }

            tradingExperienceAnswers.Add(new TradingExperience
            {
                Alias = field.Alias,
                Value = field.Value
            });
        }

        protected override void MapToField(Application application, TradingExperienceField field)
        {
            var answer = GetAnswer(field, application.Applicants[0].TradingExperiences);

            if (answer != null)
            {
                field.Value = answer.Value;
            }
        }

        private static TradingExperience GetAnswer(TradingExperienceField field, List<TradingExperience> tradingExperience)
        {
            return tradingExperience.SingleOrDefault(te => te.Alias == field.Alias);
        }
    }
}