namespace DynamicForms.Common.Models.ConfigurationModels.FieldAnnotations
{
    public abstract class FieldAnnotationBase
    {
        public string Type => GetType().Name.Replace("FieldAnnotation", null);
    }
}