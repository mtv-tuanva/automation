using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace Automation.Web.Core
{
    public interface IBrowserWait
    {
        /// <summary>
        /// Repeatedly applies this instance's input value to the given function until one
        ///     of the following occurs:
        ///     the function returns neither null nor false the function throws an exception
        ///     that is not in the list of ignored exception types the timeout expires
        /// </summary>
        /// <typeparam name="IWebDriver">A delegate taking an object of type IWebDriver as its parameter, and returning a TResult.</typeparam>
        /// <typeparam name="TResult">The delegate's expected return type.</typeparam>
        /// <param name="condition"></param>
        /// <returns>The delegate's return value.</returns>
        TResult Until<TResult>(Func<IWebDriver, TResult> condition);
        IAlert WaitUntilAlertIsPresent();
        IWebElement WaitUntilElementExists(string selector, SelectorType selectorType = SelectorType.CssSelector);
        IWebElement WaitUntilElementIsVisible(string selector, SelectorType selectorType = SelectorType.CssSelector);
        IWebElement WaitUntilElementToBeClickable(string selector, SelectorType selectorType = SelectorType.CssSelector);
        bool WaitUntilAlertState(bool state);
        bool WaitUntilElementToBeSelected(string selector, SelectorType selectorType = SelectorType.CssSelector);
        bool WaitUntilInvisibilityOfElement(string selector, SelectorType selectorType = SelectorType.CssSelector);
        bool WaitUntilInvisibilityOfElementWithText(string selector, string text, SelectorType selectorType = SelectorType.CssSelector);
        ReadOnlyCollection<IWebElement> WaitUntilVisibilityOfAllElements(string selector, SelectorType selectorType = SelectorType.CssSelector);
        bool WaitUntilTextToBePresentInElement(string selector, string text, SelectorType selectorType = SelectorType.CssSelector);
        bool WaitUntilTitleContains(string title);
        bool WaitUntilTitleIs(string title);
        bool WaitUntilUrlContains(string fraction);
        bool WaitUntilUrlToBe(string url);
    }
}
