using System;

namespace DynamicForms.Common.Infrastructure.Time
{
    public abstract class TimeProvider
    {
        private static TimeProvider current;

        public static TimeProvider Current
        {
            get
            {
                if (current == null)
                {
                    current = new DefaultTimeProvider();
                }

                return current;
            }

            set { current = value; }
        }

        public abstract DateTime UtcNow { get; }
    }
}