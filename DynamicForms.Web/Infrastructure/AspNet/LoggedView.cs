using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Web.Mvc;
using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Web.Infrastructure.Logging;

namespace DynamicForms.Web.Infrastructure.AspNet
{
    public class LoggedView : IView
    {
        private readonly IView innerView;

        private readonly string name;

        public LoggedView(IView innerView, string name)
        {
            this.innerView = innerView;
            this.name = name;
        }

        // TODO: Test: Inner view is logged.
        // TODO: Test: Time elapsed is logged correctly.
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            //var stopwatch = Stopwatch.StartNew();

            //Logger.Current.LogDebug<LoggedView>("Rendering view {0}.", name);

            innerView.Render(viewContext, writer);

            //stopwatch.Stop();

            //Logger.Current.LogDebug<LoggedView>("Rendered view {0} (Time elapsed: {1}).", name, stopwatch.Elapsed.ToFormattedString());
        }

        private static string GetViewModelTypeNameIfDifferentThanViewName(string viewName, ViewContext viewContext)
        {
            if (viewContext.ViewData.Model == null)
            {
                return null;
            }

            var viewModelTypeName = viewContext.ViewData.Model.GetType().Name;
            if (viewName.EndsWith(viewModelTypeName, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var viewModelTypeNameWithoutSuffix = viewModelTypeName.Replace("WidgetViewModel", null);
            if (viewName.EndsWith(viewModelTypeNameWithoutSuffix, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            return string.Format(CultureInfo.InvariantCulture, " (viewModel: {0})", viewModelTypeName);
        }
    }
}