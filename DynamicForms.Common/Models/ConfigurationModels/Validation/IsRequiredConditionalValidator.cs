using System.Collections.Generic;
using System.Linq;

namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class IsRequiredConditionalValidator : ValidatorBase<string>
    {
        public IsRequiredConditionalValidator()
        {
            DependeeFieldValues = new List<DependeeFieldValue>();
        }

        public override string Description => "The field is required if certain conditions are met.";

        public string DependeeFieldType { get; set; }

        public string DependeeFieldAlias { get; set; }

        public List<DependeeFieldValue> DependeeFieldValues { get; set; }

        public override FieldValidationResult Validate(object value, FieldValidationContext context)
        {
            return Validate((string)value, context);
        }

        internal override FieldValidationResult Validate(string value, FieldValidationContext context)
        {
            var dependeeAnswer = context.Application.Applicants[0].TradingExperiences.SingleOrDefault(te => te.Alias == DependeeFieldAlias);

            if (dependeeAnswer == null)
            {
                return null;
            }

            var dependeeFieldValue = DependeeFieldValues.SingleOrDefault(dfv => dfv.Value == dependeeAnswer.Value);

            if (dependeeFieldValue == null)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return new FieldValidationResult
                    {
                        ErrorMessage = "The field is required."
                    };
                }

                return null;
            }

            if (!dependeeFieldValue.AnswerSubsetAllowed.Contains(value))
            {
                return new FieldValidationResult
                {
                    ErrorMessage = $"The field is required but only the following answers are allowed: {string.Join(", ", dependeeFieldValue.AnswerSubsetAllowed)}"
                };
            }

            return null;
        }

        public override string ToString()
        {
            return $"{Description} Dependee field: {DependeeFieldType}, {DependeeFieldAlias}, [{string.Join(", ", DependeeFieldValues)}].";
        }
    }

    public class DependeeFieldValue
    {
        public DependeeFieldValue()
        {
            AnswerSubsetAllowed = new List<string>();
        }

        public string Value { get; set; }

        public List<string> AnswerSubsetAllowed { get; set; }

        public override string ToString()
        {
            return $"[Dependee field answer value: {Value}, Allowed answer: {string.Join(", ", AnswerSubsetAllowed)}]";
        }
    }
}