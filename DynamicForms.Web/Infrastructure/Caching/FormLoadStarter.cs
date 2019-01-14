using System;
using System.Timers;
using DynamicForms.Web.Infrastructure.Logging;

namespace DynamicForms.Web.Infrastructure.Caching
{
    public interface IFormLoadStarter
    {
        void Start();
    }

    public class FormLoadStarter : IFormLoadStarter
    {
        private readonly IFormLoader formLoader;

        public FormLoadStarter(IFormLoader formLoader)
        {
            this.formLoader = formLoader;
        }

        public static readonly Timer Timer = new Timer(TimeSpan.FromSeconds(15).TotalMilliseconds);

        public void Start()
        {
            Timer.Elapsed += (sender, args) =>
            {
                formLoader.PreloadAllFormSteps();
            };

            Timer.Start();
        }
    }
}