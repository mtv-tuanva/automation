namespace Automation.Web.Core.PageObjectModels
{
    public class PageBase
    {
        protected readonly IBrowser Browser;

        public PageBase(IBrowser browser)
        {
            Browser = browser;
        }
    }
}
