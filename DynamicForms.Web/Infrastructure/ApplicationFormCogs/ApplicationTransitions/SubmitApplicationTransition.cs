using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Scoring;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Scoring.ScoreOutcomeMethods;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.ApplicationTransitions
{
    public interface ISubmitApplicationTransition
    {
        void Execute(ApplicationFormContext applicationFormContext);
    }

    public class SubmitApplicationTransition : ISubmitApplicationTransition
    {
        private readonly IScoringOutcomeMethodFactory scoringOutcomeMethodFactory;

        public SubmitApplicationTransition(IScoringOutcomeMethodFactory scoringOutcomeMethodFactory)
        {
            this.scoringOutcomeMethodFactory = scoringOutcomeMethodFactory;
        }

        public void Execute(ApplicationFormContext applicationFormContext)
        {
            applicationFormContext.Application.ScoringResult = CalculateApplicationScoringResult(applicationFormContext);
            applicationFormContext.Application.State = ApplicationState.Submitted;
        }

        private ScoringResult CalculateApplicationScoringResult(ApplicationFormContext applicationFormContext)
        {
            return GetScoringOutcomeMethod(applicationFormContext).CalculateOutcome(applicationFormContext);
        }

        private IScoringOutcomeMethod GetScoringOutcomeMethod(ApplicationFormContext applicationFormContext)
        {
            return this.scoringOutcomeMethodFactory.Get(applicationFormContext.Configuration);
        }
    }
}