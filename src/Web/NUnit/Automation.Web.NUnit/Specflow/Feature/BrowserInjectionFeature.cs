using Automation.Web.Core;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Automation.Web.NUnit.Specflow.Feature
{
    public class BrowserInjectionFeature : IDisposable
    {
        private readonly string _browserId;
        private IBrowser _browser;
        private bool _isDisposed;

        public BrowserInjectionFeature(string browserID)
        {
            _browserId = browserID;
        }

        [SetUp]
        public virtual void SetUp()
        {
            IBrowser browser = null;
            var runner = ((System.Reflection.TypeInfo)GetType()).GetDeclaredField("testRunner").GetValue(this) as ITestRunner;
            runner?.FeatureContext?.TryGetValue("browser", out browser);

            if (runner != null && browser == null)
            {
                try
                {
                    _browser = BrowserFactory.CreateBrowser(_browserId);
                    runner?.FeatureContext.Add("browserId", _browserId);
                    runner?.FeatureContext.Add("browser", _browser);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }

        /// <summary>
        /// Disposes the IBrowser web driver (closing the browser) after the Feature completed
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _browser?.Dispose();

            _isDisposed = true;
        }
    }
}
