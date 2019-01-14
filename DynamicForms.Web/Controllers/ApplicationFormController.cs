using System.Web.Mvc;
using Microsoft.Practices.Unity;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms;

namespace DynamicForms.Web.Controllers
{
    public class ApplicationFormController : Controller
    {
        private ApplicationFormContext applicationFormContext;

        [Dependency]
        public IApplicationFormContextService ApplicationFormContextService { get; set; }

        public ApplicationFormContext ApplicationFormContext
        {
            get
            {
                if (applicationFormContext == null)
                {
                    applicationFormContext = ApplicationFormContextService.RetrieveApplicationFormContext();
                }

                return applicationFormContext;
            }
        }
    }
}