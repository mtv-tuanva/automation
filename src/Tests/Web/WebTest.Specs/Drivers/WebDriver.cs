using Automation.Web.Core;

namespace WebTest.Specs.Drivers
{
    public class WebDriver : IDisposable
    {
        private readonly Lazy<IBrowser> _currentWebDriverLazy;
        private bool _isDisposed;

        public WebDriver()
        {
            _currentWebDriverLazy = new Lazy<IBrowser>(GetWebDriver);
        }

        public IBrowser Current => _currentWebDriverLazy.Value;

        private IBrowser GetWebDriver()
        {
            string testBrowserId = Environment.GetEnvironmentVariable("Test_Browser");
            return BrowserFactory.CreateBrowser(testBrowserId);
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Dispose();
            }

            _isDisposed = true;
        }
    }
}
