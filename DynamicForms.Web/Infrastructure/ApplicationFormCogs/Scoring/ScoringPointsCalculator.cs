using System.Linq;
using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Scoring.ScoreOutcomeMethods;
using DynamicForms.Web.Infrastructure.Logging;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Scoring
{
    public interface IScoringPointsCalculator
    {
        ScoringPoints CalculatePoints(ApplicationFormContext applicationFormContext);
    }

    public class ScoringPointsCalculator : IScoringPointsCalculator
    {
        private readonly IFieldMappingOrchestrator fieldMappingOrchestrator;

        public ScoringPointsCalculator(IFieldMappingOrchestrator fieldMappingOrchestrator)
        {
            this.fieldMappingOrchestrator = fieldMappingOrchestrator;
        }

        public ScoringPoints CalculatePoints(ApplicationFormContext applicationFormContext)
        {
            var dropDownListFields = GetSingleChoiceFields(applicationFormContext);

            fieldMappingOrchestrator.MapToFields(applicationFormContext.Application, dropDownListFields);

            var scoringPoints = new ScoringPoints();

            foreach (var field in dropDownListFields)
            {
                var availableValue = field.AvailableValues.SingleOrDefault(v => v.Value == field.Value);

                if (availableValue == null)
                {
                    Logger.Current.LogDebug<DefaultScoringOutcomeMethod>($"The field '{field.Alias}' does not have a selected value.");
                    continue;
                }

                scoringPoints.PointsOutline.Add(new ScoringPointsOutlineItem
                {
                    FieldAlias = field.Alias,
                    FieldLabel = field.Label,
                    FieldText = availableValue.Text,
                    Score = availableValue.Score
                });
            }

            scoringPoints.Points = scoringPoints.PointsOutline.Sum(i => i.Score);

            return scoringPoints;
        }

        private static SingleChoiceFieldBase[] GetSingleChoiceFields(ApplicationFormContext applicationFormContext)
        {
            return applicationFormContext
                .Configuration
                .Experiences[0]
                .Navigation
                .Steps
                .SelectMany(s => s.Sections)
                .SelectMany(s => s.Fields)
                .OfType<SingleChoiceFieldBase>()
                .ToArray();
        }
    }
}