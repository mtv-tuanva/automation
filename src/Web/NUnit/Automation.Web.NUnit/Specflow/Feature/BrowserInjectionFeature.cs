using Automation.Web.Core;
using NUnit.Framework;
using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Automation.Web.NUnit.Specflow.Feature
{
    /// <summary>
    /// The BrowserInjectionFeature class is used to extend your generated class xxx.feature.cs to inject multiple browser into the same feature.
    /// If will help you to execute multiple browsers using the same Feature/scenario
    /// </summary>
    public class BrowserInjectionFeature : IDisposable
    {
        private readonly string _browserId;
        private IBrowser _browser;
        private bool _isDisposed;

        public BrowserInjectionFeature(string browserID)
        {
            _browserId = browserID;
        }

        /// <summary>
        /// Inject browrser & browserId into FeatureContext when setup the test
        /// </summary>
        [SetUp]
        public virtual void SetUp()
        {
            IBrowser browser = null;
            TypeInfo type = (TypeInfo)GetType();
            FieldInfo fieldInfo;
            ITestRunner runner = null;

            while (runner == null || type == null)
            {
                fieldInfo = type.GetDeclaredField("testRunner");
                runner = fieldInfo?.GetValue(this) as ITestRunner;
                type = (TypeInfo)type.BaseType;
            }

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
