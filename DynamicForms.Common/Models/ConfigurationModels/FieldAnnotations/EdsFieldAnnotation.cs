namespace DynamicForms.Common.Models.ConfigurationModels.FieldAnnotations
{
    public class EdsFieldAnnotation : FieldAnnotationBase
    {
        public string Field { get; set; }

        public override string ToString()
        {
            return $"Field: {Field}";
        }
    }
}