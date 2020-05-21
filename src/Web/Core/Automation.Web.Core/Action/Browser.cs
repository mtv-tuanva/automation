using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.Web.Core
{
    public partial class Browser : IBrowserAction
    {
        public Actions Actions => new Actions(WebDriver);

        public void Click() => Actions.Click().Perform();

        public void Click(IWebElement onElement)
            => Actions.Click(onElement).Perform();

        public void Click(string selector, SelectorType selectorType = SelectorType.CssSelector, int selectIndex = 0)
            => Click(FindElement(selector, selectorType, selectIndex));

        public void DoubleClick()
            => Actions.DoubleClick().Perform();

        public void DoubleClick(IWebElement onElement)
            => Actions.DoubleClick(onElement).Perform();

        public void DoubleClick(string selector, SelectorType selectorType = SelectorType.CssSelector, int selectIndex = 0)
            => DoubleClick(FindElement(selector, selectorType, selectIndex));

        public void KeyDown(IWebElement element, string theKey)
            => Actions.KeyDown(element, theKey).Perform();

        public void KeyDown(string theKey)
            => Actions.KeyDown(theKey).Perform();

        public void KeyDown(string selector, string theKey, SelectorType selectorType = SelectorType.CssSelector, int selectIndex = 0)
            => KeyDown(FindElement(selector, selectorType, selectIndex), theKey);

        public void KeyUp(IWebElement element, string theKey)
            => Actions.KeyDown(element, theKey).Perform();

        public void KeyUp(string theKey)
            => Actions.KeyUp(theKey).Perform();

        public void KeyUp(string selector, string theKey, SelectorType selectorType = SelectorType.CssSelector, int selectIndex = 0)
            => KeyUp(FindElement(selector, selectorType, selectIndex), theKey);

        public void ScrollTo(IWebElement webElement)
            => Actions.MoveToElement(webElement).Perform();

        public void ScrollTo(string selector, SelectorType selectorType = SelectorType.CssSelector, int selectIndex = 0)
            => ScrollTo(FindElement(selector, selectorType, selectIndex));

        public void SendKeys(IWebElement element, string keysToSend)
            => Actions.SendKeys(element, keysToSend).Perform();

        public void SendKeys(string keysToSend)
            => Actions.SendKeys(keysToSend).Perform();

        public void SendKeys(string selector, string keysToSend, SelectorType selectorType = SelectorType.CssSelector, int selectIndex = 0)
            => SendKeys(FindElement(selector, selectorType, selectIndex), keysToSend);
    }
}
