using System.Web.Mvc;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms;

namespace DynamicForms.Web.Infrastructure.AspNet
{
    public class ApplicationFormViewPage<T> : WebViewPage<T>
    {
        public ApplicationFormViewPage()
        {
            ApplicationFormContext = DependencyResolver.Current.GetService<ApplicationFormContext>();
            ApplicationSettings = DependencyResolver.Current.GetService<IApplicationSettings>();
        }

        public ApplicationFormContext ApplicationFormContext { get; }

        public IApplicationSettings ApplicationSettings { get; }

        public override void Execute()
        {
        }
    }
}