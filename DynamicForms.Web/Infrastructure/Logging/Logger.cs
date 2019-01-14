using System;
using JetBrains.Annotations;

namespace DynamicForms.Web.Infrastructure.Logging
{
    public abstract class Logger
    {
        private static Logger current;

        public static Logger Current
        {
            get
            {
                if (current == null)
                {
                    current = new DefaultLogger();
                }

                return current;
            }

            set { current = value; }
        }

        public abstract void LogFatal<T>(string message, Exception exception);

        public abstract void LogFatal<T>(string message);

        [StringFormatMethod("format")]
        public abstract void LogFatal<T>(string format, params object[] args);

        public abstract void LogFatal<T>(Exception exception);

        public abstract void LogError<T>(string message, Exception exception);

        public abstract void LogError<T>(string message);

        [StringFormatMethod("format")]
        public abstract void LogError<T>(string format, params object[] args);

        public abstract void LogError<T>(Exception exception);

        public abstract void LogWarn<T>(string message, Exception exception);

        public abstract void LogWarn<T>(string message);

        [StringFormatMethod("format")]
        public abstract void LogWarn<T>(string format, params object[] args);

        public abstract void LogWarn<T>(Exception exception);

        public abstract void LogInfo<T>(string message, Exception exception);

        public abstract void LogInfo<T>(string message);

        [StringFormatMethod("format")]
        public abstract void LogInfo<T>(string format, params object[] args);

        public abstract void LogInfo<T>(Exception exception);

        public abstract void LogDebug<T>(string message, Exception exception);

        public abstract void LogDebug<T>(string message);

        [StringFormatMethod("format")]
        public abstract void LogDebug<T>(string format, params object[] args);

        public abstract void LogDebug<T>(Exception exception);
    }
}