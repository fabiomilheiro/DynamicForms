using System.Linq;
using System.Web.Mvc;

namespace DynamicForms.Web.Infrastructure.AspNet
{
    public class ApplicationFormViewEngine : RazorViewEngine
    {
        public ApplicationFormViewEngine()
        {
            PartialViewLocationFormats = PartialViewLocationFormats.Union(new[]
            {
                "~/Views/Blocks/{0}.cshtml"
            }).ToArray();

            AreaMasterLocationFormats = Filter(AreaMasterLocationFormats);
            AreaPartialViewLocationFormats = Filter(AreaPartialViewLocationFormats);
            AreaViewLocationFormats = Filter(AreaViewLocationFormats);
            FileExtensions = Filter(FileExtensions);
            MasterLocationFormats = Filter(MasterLocationFormats);
            PartialViewLocationFormats = Filter(PartialViewLocationFormats);
            ViewLocationFormats = Filter(ViewLocationFormats);
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName,
            bool useCache)
        {
            return CreateViewEngineResultWithLogging(
                base.FindPartialView(controllerContext, partialViewName, useCache),
                partialViewName);
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName,
            string masterName, bool useCache)
        {
            return CreateViewEngineResultWithLogging(
                base.FindView(controllerContext, viewName, masterName, useCache),
                viewName);
        }

        private static string[] Filter(string[] source)
        {
            return source.Where(s => s.Contains("cshtml")).ToArray();
        }

        private ViewEngineResult CreateViewEngineResultWithLogging(ViewEngineResult viewEngineResult, string viewName)
        {
            if (viewEngineResult.View == null)
            {
                return viewEngineResult;
            }

            var razorView = (RazorView) viewEngineResult.View;

            if (viewName.StartsWith("_"))
            {
                return viewEngineResult;
            }

            if (razorView.ViewPath.StartsWith("~/Views/Shared/EditorTemplates"))
            {
                return viewEngineResult;
            }

            return new ViewEngineResult(new LoggedView(viewEngineResult.View, viewName), this);
        }
    }
}