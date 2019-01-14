using System;

namespace DynamicForms.Common.Infrastructure.Time
{
    public class DefaultTimeProvider : TimeProvider
    {
        public override DateTime UtcNow => DateTime.UtcNow;
    }
}