using System.Collections.Generic;

namespace DynamicForms.Common.Models.ApplicationModels
{
    public class ScoringPoints
    {
        public ScoringPoints()
        {
            this.PointsOutline = new List<ScoringPointsOutlineItem>();
        }

        public int Points { get; set; }

        public List<ScoringPointsOutlineItem> PointsOutline { get; set; }
    }
}