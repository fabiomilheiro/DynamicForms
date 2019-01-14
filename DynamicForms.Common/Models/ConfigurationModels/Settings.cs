namespace DynamicForms.Common.Models.ConfigurationModels
{
    public class Settings
    {
        public Settings()
        {
            Brand = new Brand();
        }

        public Brand Brand { get; set; }

        public ContactInformation Contact { get; set; }
    }
}