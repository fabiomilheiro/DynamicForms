namespace DynamicForms.Common.Models.ApplicationModels
{
    public class ScoringOutcomeRange
    {
        public ScoringOutcomeRange(int? minimum, int? maximum, ScoringOutcome scoringOutcome)
        {
            Minimum = minimum;
            Maximum = maximum;
            ScoringOutcome = scoringOutcome;
        }

        public int? Minimum { get; set; }

        public int? Maximum { get; set; }

        public ScoringOutcome ScoringOutcome { get; set; }

        public string RangeAsString
        {
            get
            {
                if (!Minimum.HasValue)
                {
                    return $"Up to {Maximum}";
                }

                if (!Maximum.HasValue)
                {
                    return $"{Minimum} or more";
                }

                return $"Between {Minimum} and {Maximum} (inclusive)";
            }
        }
    }
}