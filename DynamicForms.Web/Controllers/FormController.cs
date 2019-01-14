using System.Web.Mvc;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.Web.Infrastructure.Repositories;

namespace DynamicForms.Web.Controllers
{
    public class FormController : Controller
    {
        private readonly IConfigurationRepository configurationRepository;

        public FormController(IConfigurationRepository configurationRepository)
        {
            this.configurationRepository = configurationRepository;
        }

        [Route("~/Form/{formID:alpha}/{versionID:int?}")]
        public ActionResult Index(string formID, int? versionID)
        {
            if (versionID.HasValue)
            {
                return View(configurationRepository.RetrieveConfiguration(formID, versionID.Value));
            }

            return View(configurationRepository.RetrieveConfiguration(formID));
        }
    }
}