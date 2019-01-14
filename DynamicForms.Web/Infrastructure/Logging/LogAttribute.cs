//using System.Diagnostics;
//using System.Web.Mvc;
//using DynamicForms.Common.Infrastructure.Helpers;

//namespace DynamicForms.Web.Infrastructure.Logging
//{
//    public class LogAttribute : ActionFilterAttribute
//    {
//        public override void OnActionExecuted(ActionExecutedContext filterContext)
//        {
//            Logger.Current.LogInfo<LogAttribute>("Starting to execute action.");
//        }



//        private string GetElapsedTime()
//        {
//            var stopwatch = RequestWrapper.RetrieveRequestItem<Stopwatch>(StopwatchItemKey);
//            stopwatch.Stop();

//            return stopwatch.Elapsed.ToFormattedString();
//        }
//    }
//}