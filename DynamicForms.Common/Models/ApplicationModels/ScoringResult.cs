using System.Collections.Generic;

namespace DynamicForms.Common.Models.ApplicationModels
{
    public class ScoringResult
    {
        public ScoringResult()
        {
            this.PointsOutline = new List<ScoringPointsOutlineItem>();
        }

        public int Points { get; set; }

        public List<ScoringPointsOutlineItem> PointsOutline { get; set; }

        public ScoringOutcome Outcome { get; set; }

        public List<ScoringOutcomeOutlineItem> OutcomeOutline { get; set; }
    }
}