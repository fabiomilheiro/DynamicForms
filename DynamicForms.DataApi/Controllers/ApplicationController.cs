using System;
using System.Web.Http;
using DynamicForms.DataApi.Repositories;
using DynamicForms.Common.Models.ApplicationModels;

namespace DynamicForms.DataApi.Controllers
{
    public class ApplicationController : ApiController
    {
        private readonly IApplicationRepository applicationRepository;

        public ApplicationController(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public Application Get(string id)
        {
            return applicationRepository.RetrieveApplication(id);
        }

        public Application Post(Application application)
        {
            applicationRepository.SaveApplication(application);

            return application;
        }
    }
}