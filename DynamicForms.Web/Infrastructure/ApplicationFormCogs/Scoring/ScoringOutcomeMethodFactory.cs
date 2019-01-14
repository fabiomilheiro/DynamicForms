using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Scoring.ScoreOutcomeMethods;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Scoring
{
    public interface IScoringOutcomeMethodFactory
    {
        IScoringOutcomeMethod Get(FormConfiguration formConfiguration);
    }

    public class ScoringOutcomeMethodFactory : IScoringOutcomeMethodFactory
    {
        private readonly DefaultScoringOutcomeMethod defaultScoringOutcomeMethod;

        public ScoringOutcomeMethodFactory(DefaultScoringOutcomeMethod defaultScoringOutcomeMethod)
        {
            this.defaultScoringOutcomeMethod = defaultScoringOutcomeMethod;
        }

        public IScoringOutcomeMethod Get(FormConfiguration formConfiguration)
        {
            return this.defaultScoringOutcomeMethod;
        }
    }
}