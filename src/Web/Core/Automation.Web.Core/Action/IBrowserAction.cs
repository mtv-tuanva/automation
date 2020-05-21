using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.Web.Core
{
    public interface IBrowserAction
    {
        Actions Actions { get; }

        /// <summary>
        /// Clicks the mouse at the last known mouse coordinates.
        /// </summary>
        void Click();

        /// <summary>
        /// Clicks the mouse on the specified element.
        /// </summary>
        /// <param name="onElement">The element on which to click.</param>
        void Click(IWebElement onElement);

        /// <summary>
        /// Double-clicks the mouse at the last known mouse coordinates.
        /// </summary>
        /// <returns></returns>
        void DoubleClick();

        /// <summary>
        /// Double-clicks the mouse on the specified element.
        /// </summary>
        /// <param name="onElement">The element on which to double-click.</param>
        void DoubleClick(IWebElement onElement);

        /// <summary>
        /// Sends a modifier key down message to the specified element in the browser.
        /// </summary>
        /// <param name="element">The element to which to send the key command.</param>
        /// <param name="theKey">The key to be sent.</param>
        /// <exception cref="System.ArgumentException">
        /// If the key sent is not is not one of OpenQA.Selenium.Keys.Shift, OpenQA.Selenium.Keys.Control,
        ///     OpenQA.Selenium.Keys.Alt, OpenQA.Selenium.Keys.Meta, OpenQA.Selenium.Keys.Command,OpenQA.Selenium.Keys.LeftAlt,
        ///     OpenQA.Selenium.Keys.LeftControl,OpenQA.Selenium.Keys.LeftShift.
        ///</exception>
        void KeyDown(IWebElement element, string theKey);

        /// <summary>
        /// Sends a modifier key down message to the browser.
        /// </summary>
        /// <param name="theKey">The key to be sent.</param>
        /// <exception cref="System.ArgumentException">
        /// If the key sent is not is not one of OpenQA.Selenium.Keys.Shift, OpenQA.Selenium.Keys.Control,
        ///     OpenQA.Selenium.Keys.Alt, OpenQA.Selenium.Keys.Meta, OpenQA.Selenium.Keys.Command,OpenQA.Selenium.Keys.LeftAlt,
        ///     OpenQA.Selenium.Keys.LeftControl,OpenQA.Selenium.Keys.LeftShift.
        ///</exception>
        void KeyDown(string theKey);
        
        /// <summary>
        /// Sends a modifier up down message to the specified element in the browser.
        /// </summary>
        /// <param name="element">The element to which to send the key command.</param>
        /// <param name="theKey">The key to be sent.</param>
        /// <exception cref="System.ArgumentException">
        /// If the key sent is not is not one of OpenQA.Selenium.Keys.Shift, OpenQA.Selenium.Keys.Control,
        ///     OpenQA.Selenium.Keys.Alt, OpenQA.Selenium.Keys.Meta, OpenQA.Selenium.Keys.Command,OpenQA.Selenium.Keys.LeftAlt,
        ///     OpenQA.Selenium.Keys.LeftControl,OpenQA.Selenium.Keys.LeftShift.
        ///</exception>
        void KeyUp(IWebElement element, string theKey);
        
        /// <summary>
        /// Sends a modifier key up message to the browser.
        /// </summary>
        /// <param name="theKey">The key to be sent.</param>
        /// If the key sent is not is not one of OpenQA.Selenium.Keys.Shift, OpenQA.Selenium.Keys.Control,
        ///     OpenQA.Selenium.Keys.Alt, OpenQA.Selenium.Keys.Meta, OpenQA.Selenium.Keys.Command,OpenQA.Selenium.Keys.LeftAlt,
        ///     OpenQA.Selenium.Keys.LeftControl,OpenQA.Selenium.Keys.LeftShift.
        ///</exception>
        void KeyUp(string theKey);

        /// <summary>
        /// Sends a sequence of keystrokes to the specified element in the browser.
        /// </summary>
        /// <param name="element">The element to which to send the keystrokes.</param>
        /// <param name="keysToSend">The keystrokes to send to the browser.</param>
        void SendKeys(IWebElement element, string keysToSend);

        /// <summary>
        /// Sends a sequence of keystrokes to the browser.
        /// </summary>
        /// <param name="keysToSend">The keystrokes to send to the browser.</param>
        void SendKeys(string keysToSend);

        /// <summary>
        /// Scroll to the element
        /// </summary>
        /// <param name="webElement">The element that will be scrolled to.</param>
        void ScrollTo(IWebElement webElement);
    }
}
