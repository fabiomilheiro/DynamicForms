using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Common.Models.ConfigurationModels;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms
{
    public class ApplicationFormContext
    {
        public FormConfiguration Configuration { get; set; }

        public Application Application { get; set; }

        public Application PreviousApplicationState { get; set; }
    }
}