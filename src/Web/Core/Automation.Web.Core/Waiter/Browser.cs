using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Automation.Web.Core
{
    public partial class Browser : IBrowserWait
    {
        public TResult Until<TResult>(Func<IWebDriver, TResult> condition) => Wait.Until(condition);

        public IAlert WaitUntilAlertIsPresent() => Wait.Until(ExpectedConditions.AlertIsPresent());

        public bool WaitUntilAlertState(bool state) => Wait.Until(ExpectedConditions.AlertState(state));

        public IWebElement WaitUntilElementExists(string selector, SelectorType selectorType = SelectorType.CssSelector)
            => Wait.Until(ExpectedConditions.ElementExists(GetBy(selector, selectorType)));

        public IWebElement WaitUntilElementIsVisible(string selector, SelectorType selectorType = SelectorType.CssSelector)
            => Wait.Until(ExpectedConditions.ElementIsVisible(GetBy(selector, selectorType)));

        public IWebElement WaitUntilElementToBeClickable(string selector, SelectorType selectorType = SelectorType.CssSelector)
            => Wait.Until(ExpectedConditions.ElementToBeClickable(GetBy(selector, selectorType)));

        public bool WaitUntilElementToBeSelected(string selector, SelectorType selectorType = SelectorType.CssSelector)
            => Wait.Until(ExpectedConditions.ElementToBeSelected(GetBy(selector, selectorType)));

        public bool WaitUntilInvisibilityOfElement(string selector, SelectorType selectorType = SelectorType.CssSelector)
            => Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(GetBy(selector, selectorType)));

        public bool WaitUntilInvisibilityOfElementWithText(string selector, string text, SelectorType selectorType = SelectorType.CssSelector)
            => Wait.Until(ExpectedConditions.InvisibilityOfElementWithText(GetBy(selector, selectorType), text));

        public ReadOnlyCollection<IWebElement> WaitUntilVisibilityOfAllElements(string selector, SelectorType selectorType = SelectorType.CssSelector)
            => Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(GetBy(selector, selectorType)));

        public bool WaitUntilTextToBePresentInElement(string selector, string text, SelectorType selectorType = SelectorType.CssSelector)
            => Wait.Until(ExpectedConditions.TextToBePresentInElementLocated(GetBy(selector, selectorType), text));

        public bool WaitUntilTitleContains(string title)
            => Wait.Until(ExpectedConditions.TitleContains(title));

        public bool WaitUntilTitleIs(string title)
            => Wait.Until(ExpectedConditions.TitleIs(title));

        public bool WaitUntilUrlContains(string fraction)
            => Wait.Until(ExpectedConditions.UrlContains(fraction));

        public bool WaitUntilUrlToBe(string url)
            => Wait.Until(ExpectedConditions.UrlToBe(url));
    }
}
