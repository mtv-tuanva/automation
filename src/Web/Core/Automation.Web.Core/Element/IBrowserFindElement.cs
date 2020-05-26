using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Automation.Web.Core
{
    public interface IBrowserFindElement
    {
        /// <summary>
        /// Finds the element matching the specified selector with the specified index.
        /// </summary>
        /// <param name="selector">The selector to match</param>
        /// <param name="selectorType">The selector type</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <param name="waitUntilElementIsVisible">Indicate that it should wait until the element is visible before the timeout</param>
        /// <returns>The first OpenQA.Selenium.IWebElement matching the criteria.</returns>
        IWebElement FindElement(string selector, SelectorType selectorType = SelectorType.CssSelector, int selectIndex = 0, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds the element in the page that matches the class supplied with the specified index.
        /// </summary>
        /// <param name="className">Class name of the element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <param name="waitUntilElementIsVisible">Indicate that it should wait until the element is visible before the timeout</param>
        /// <returns>IWebElement object so that you can interact with that object</returns>
        IWebElement FindElementByClassName(string className, int selectIndex = 0, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds the element matching the specified Css selector with the specified index.
        /// </summary>
        /// <param name="cssSelector">The Css selector to match</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <param name="waitUntilElementIsVisible">Indicate that it should wait until the element is visible before the timeout</param>
        /// <returns>The first OpenQA.Selenium.IWebElement matching the criteria.</returns>
        IWebElement FindElementByCssSelector(string cssSelector, int selectIndex = 0, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds the element in the page that matches the ID supplied with the specified index.
        /// </summary>
        /// <param name="id">ID of the element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <param name="waitUntilElementIsVisible">Indicate that it should wait until the element is visible before the timeout</param>
        /// <returns>IWebElement object so that you can interact with that object</returns>
        IWebElement FindElementById(string id, int selectIndex = 0, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds the elements that match the link text supplied with the specified index.
        /// </summary>
        /// <param name="linkText">Link text of element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <param name="waitUntilElementIsVisible">Indicate that it should wait until the element is visible before the timeout</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        IWebElement FindElementByLinkText(string linkText, int selectIndex = 0, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds the elements that match the name supplied with the specified index.
        /// </summary>
        /// <param name="name">Name of the element on the page</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <param name="waitUntilElementIsVisible">Indicate that it should wait until the element is visible before the timeout</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        IWebElement FindElementByName(string name, int selectIndex = 0, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds the elements that match the part of the link text supplied with the specified index.
        /// </summary>
        /// <param name="partialLinkText">part of the link text</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <param name="waitUntilElementIsVisible">Indicate that it should wait until the element is visible before the timeout</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        IWebElement FindElementByPartialLinkText(string partialLinkText, int selectIndex = 0, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds the elements that match the DOM Tag supplied with the specified index.
        /// </summary>
        /// <param name="tagName">DOM tag Name of the element being searched</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <param name="waitUntilElementIsVisible">Indicate that it should wait until the element is visible before the timeout</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        IWebElement FindElementByTagName(string tagName, int selectIndex = 0, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds the elements that match the XPath supplied with the specified index.
        /// </summary>
        /// <param name="xpath">xpath to the element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        IWebElement FindElementByXPath(string xpath, int selectIndex = 0, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds the elements on the page by using the OpenQA.Selenium.By object and returns
        ///     a ReadOnlyCollection of the Elements on the page
        /// </summary>
        /// <param name="selector">The selector to find the element</param>
        /// <param name="selectorType">The type of selector</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>ReadOnlyCollection of IWebElement</returns>
        ReadOnlyCollection<IWebElement> FindElements(string selector, SelectorType selectorType = SelectorType.CssSelector, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds a list of elements that match the class name supplied
        /// </summary>
        /// <param name="className">CSS class Name on the element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>ReadOnlyCollection of IWebElement object so that you can interact with those objects</returns>
        ReadOnlyCollection<IWebElement> FindElementsByClassName(string className, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds all elements matching the specified CSS selector.
        /// </summary>
        /// <param name="cssSelector">The CSS selector to match.</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>A System.Collections.ObjectModel.ReadOnlyCollection`1 containing all OpenQA.Selenium.IWebElement matching the criteria.</returns>
        ReadOnlyCollection<IWebElement> FindElementsByCssSelector(string cssSelector, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds the first element in the page that matches the ID supplied
        /// </summary>
        /// <param name="id">ID of the Element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>ReadOnlyCollection of Elements that match the object so that you can interact that object</returns>
        ReadOnlyCollection<IWebElement> FindElementsById(string id, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds a list of elements that match the link text supplied
        /// </summary>
        /// <param name="linkText">Link text of element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>ReadOnlyCollection object so that you can interact with those objects</returns>
        ReadOnlyCollection<IWebElement> FindElementsByLinkText(string linkText, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds a list of elements that match the name supplied
        /// </summary>
        /// <param name="name">Name of element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>ReadOnlyCollect of IWebElement objects so that you can interact that object</returns>
        ReadOnlyCollection<IWebElement> FindElementsByName(string name, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds a list of elements that match the class name supplied
        /// </summary>
        /// <param name="partialLinkText">part of the link text</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>ReadOnlyCollection objects so that you can interact that object</returns>
        ReadOnlyCollection<IWebElement> FindElementsByPartialLinkText(string partialLinkText, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds a list of elements that match the DOM Tag supplied
        /// </summary>
        /// <param name="tagName">DOM tag Name of element being searched</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        ReadOnlyCollection<IWebElement> FindElementsByTagName(string tagName, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds a list of elements that match the XPath supplied
        /// </summary>
        /// <param name="xpath">xpath to the element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>ReadOnlyCollection of IWebElement objects so that you can interact that object</returns>
        ReadOnlyCollection<IWebElement> FindElementsByXPath(string xpath, bool waitUntilElementIsVisible = true);

        /// <summary>
        /// Finds the select element (dropdownlist) matching the specified selector with the specified index.
        /// </summary>
        /// <param name="selector">The selector to match</param>
        /// <param name="selectorType">The selector type</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>The OpenQA.Selenium.Support.UI.SelectElement matching the criteria.</returns>
        SelectElement FindSelectElement(string selector, SelectorType selectorType = SelectorType.CssSelector, int selectIndex = 0, bool waitUntilElementIsVisible = true);
    }
}
