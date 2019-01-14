using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using log4net;
using log4net.Config;
using DynamicForms.Common.Infrastructure.Constants;

namespace DynamicForms.Web.Infrastructure.Logging
{
    public class DefaultLogger : Logger
    {
        private static readonly Dictionary<Type, ILog> Loggers = new Dictionary<Type, ILog>();

        public DefaultLogger()
        {
            XmlConfigurator.Configure();
        }

        public override void LogFatal<T>(string message, Exception exception)
        {
            Log<T>(l => l.IsFatalEnabled, l => l.Fatal(GetCurrentSession() + message, exception));
        }

        public override void LogFatal<T>(string message)
        {
            Log<T>(l => l.IsFatalEnabled, l => l.Fatal(GetCurrentSession() + message));
        }

        public override void LogFatal<T>(string format, params object[] args)
        {
            Log<T>(l => l.IsFatalEnabled,
                l => l.FatalFormat(CultureInfo.InvariantCulture, GetCurrentSession() + format, args));
        }

        public override void LogFatal<T>(Exception exception)
        {
            Log<T>(l => l.IsFatalEnabled, l => l.Fatal(exception));
        }

        public override void LogError<T>(string message, Exception exception)
        {
            Log<T>(l => l.IsErrorEnabled, l => l.Error(GetCurrentSession() + message, exception));
        }

        public override void LogError<T>(string message)
        {
            Log<T>(l => l.IsErrorEnabled, l => l.Error(GetCurrentSession() + message));
        }

        public override void LogError<T>(string format, params object[] args)
        {
            Log<T>(l => l.IsErrorEnabled,
                l => l.ErrorFormat(CultureInfo.InvariantCulture, GetCurrentSession() + format, args));
        }

        public override void LogError<T>(Exception exception)
        {
            Log<T>(l => l.IsErrorEnabled, l => l.Error(exception));
        }

        public override void LogWarn<T>(string message, Exception exception)
        {
            Log<T>(l => l.IsWarnEnabled, l => l.Warn(GetCurrentSession() + message, exception));
        }

        public override void LogWarn<T>(string message)
        {
            Log<T>(l => l.IsWarnEnabled, l => l.Warn(GetCurrentSession() + message));
        }

        public override void LogWarn<T>(string format, params object[] args)
        {
            Log<T>(l => l.IsWarnEnabled,
                l => l.WarnFormat(CultureInfo.InvariantCulture, GetCurrentSession() + format, args));
        }

        public override void LogWarn<T>(Exception exception)
        {
            Log<T>(l => l.IsWarnEnabled, l => l.Warn(exception));
        }

        public override void LogInfo<T>(string message, Exception exception)
        {
            Log<T>(l => l.IsInfoEnabled, l => l.Info(GetCurrentSession() + message, exception));
        }

        public override void LogInfo<T>(string message)
        {
            Log<T>(l => l.IsInfoEnabled, l => l.Info(GetCurrentSession() + message));
        }

        public override void LogInfo<T>(string format, params object[] args)
        {
            Log<T>(l => l.IsInfoEnabled,
                l => l.InfoFormat(CultureInfo.InvariantCulture, GetCurrentSession() + format, args));
        }

        public override void LogInfo<T>(Exception exception)
        {
            Log<T>(l => l.IsInfoEnabled, l => l.Info(exception));
        }

        public override void LogDebug<T>(string message, Exception exception)
        {
            Log<T>(l => l.IsDebugEnabled, l => l.Debug(GetCurrentSession() + message, exception));
        }

        public override void LogDebug<T>(string message)
        {
            Log<T>(l => l.IsDebugEnabled, l => l.Debug(GetCurrentSession() + message));
        }

        public override void LogDebug<T>(string format, params object[] args)
        {
            Log<T>(l => l.IsDebugEnabled,
                l => l.DebugFormat(CultureInfo.InvariantCulture, GetCurrentSession() + format, args));
        }

        public override void LogDebug<T>(Exception exception)
        {
            Log<T>(l => l.IsDebugEnabled, l => l.Debug(exception));
        }

        private static void Log<T>(Func<ILog, bool> predicate, Action<ILog> logAction)
        {
            var loggerType = typeof(T);

            if (!Loggers.ContainsKey(loggerType))
            {
                Loggers[loggerType] = LogManager.GetLogger(loggerType);
            }

            var logger = Loggers[loggerType];

            if (predicate(logger))
            {
                logAction(logger);
            }
        }

        private static string GetCurrentSession()
        {
            //if (HttpContext.Current != null && HttpContext.Current.Handler != null)
            //{
            //    return string.Format(
            //        CultureInfo.InvariantCulture,
            //        "[{0}] ",
            //        HttpContext.Current.Request.QueryString[QueryStringParameters.ApplicationID] ??
            //        HttpContext.Current.Request.UserHostAddress);
            //}

            return string.Empty;
        }
    }
}