using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Scoring.ScoreOutcomeMethods
{
    public interface IScoringOutcomeMethod
    {
        ScoringResult CalculateOutcome(ApplicationFormContext applicationFormContext);
    }
}