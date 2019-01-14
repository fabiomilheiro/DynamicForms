using System.Linq;
using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Scoring.ScoreOutcomeMethods
{
    public class DefaultScoringOutcomeMethod : IScoringOutcomeMethod
    {
        private readonly IScoringPointsCalculator scoringPointsCalculator;

        public DefaultScoringOutcomeMethod(IScoringPointsCalculator scoringPointsCalculator)
        {
            this.scoringPointsCalculator = scoringPointsCalculator;
        }

        public ScoringResult CalculateOutcome(ApplicationFormContext applicationFormContext)
        {
            var scoringPoints = this.scoringPointsCalculator.CalculatePoints(applicationFormContext);

            var scoringResult = new ScoringResult
            {
                Points = scoringPoints.Points,
                PointsOutline = scoringPoints.PointsOutline
            };

            return CalculateOutcome(scoringResult);
        }

        private static ScoringResult CalculateOutcome(ScoringResult scoringResult)
        {
            scoringResult.OutcomeOutline = Ranges.Select(range => new ScoringOutcomeOutlineItem
            {
                IsFinalOutcome = Matches(scoringResult.Points, range),
                Range = range
            }).ToList();

            scoringResult.Outcome = scoringResult.OutcomeOutline.Single(i => i.IsFinalOutcome).Range.ScoringOutcome;

            return scoringResult;
        }

        private static readonly ScoringOutcomeRange[] Ranges = new[]
        {
            new ScoringOutcomeRange(null, 3, ScoringOutcome.Reject),
            new ScoringOutcomeRange(4, 5, ScoringOutcome.Warning),
            new ScoringOutcomeRange(6, null, ScoringOutcome.Pass)
        };

        private static bool Matches(int points, ScoringOutcomeRange range)
        {
            if (!range.Minimum.HasValue)
            {
                return points <= range.Maximum;
            }

            if (!range.Maximum.HasValue)
            {
                return points >= range.Minimum;
            }

            return points >= range.Minimum && points <= range.Maximum;
        }
    }
}
 