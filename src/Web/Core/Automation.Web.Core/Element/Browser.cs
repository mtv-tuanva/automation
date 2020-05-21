using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Web.Core
{
    public partial class Browser : IBrowserFindElement
    {
        /// <summary>
        /// Finds the element matching the specified selector with the specified index.
        /// </summary>
        /// <param name="selector">The selector to match</param>
        /// <param name="selectorType">The selector type</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>The first OpenQA.Selenium.IWebElement matching the criteria.</returns>
        public IWebElement FindElement(string selector, SelectorType selectorType = SelectorType.CssSelector, int selectIndex = 0)
        {
            return Until((driver) => selectIndex > 0 ? driver.FindElements(GetBy(selector, selectorType))[0] : driver.FindElement(GetBy(selector, selectorType)));
        }

        /// <summary>
        /// Finds the element in the page that matches the class supplied with the specified index.
        /// </summary>
        /// <param name="className">Class name of the element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>IWebElement object so that you can interact with that object</returns>
        public IWebElement FindElementByClassName(string className, int selectIndex = 0)
            => Until((driver) => selectIndex > 0 ? WebDriver.FindElementsByClassName(className)[selectIndex] : WebDriver.FindElementByClassName(className));

        /// <summary>
        /// Finds the element matching the specified Css selector with the specified index.
        /// </summary>
        /// <param name="cssSelector">The Css selector to match</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>The first OpenQA.Selenium.IWebElement matching the criteria.</returns>
        public IWebElement FindElementByCssSelector(string cssSelector, int selectIndex = 0)
            => Until((driver) => selectIndex > 0 ? WebDriver.FindElementsByCssSelector(cssSelector)[selectIndex] : WebDriver.FindElementByCssSelector(cssSelector));

        /// <summary>
        /// Finds the element in the page that matches the ID supplied with the specified index.
        /// </summary>
        /// <param name="id">ID of the element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>IWebElement object so that you can interact with that object</returns>
        public IWebElement FindElementById(string id, int selectIndex = 0)
            => Until((driver) => selectIndex > 0 ? WebDriver.FindElementsById(id)[selectIndex] : WebDriver.FindElementById(id));

        /// <summary>
        /// Finds the elements that match the link text supplied with the specified index.
        /// </summary>
        /// <param name="linkText">Link text of element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        public IWebElement FindElementByLinkText(string linkText, int selectIndex = 0)
            => Until((driver) => selectIndex > 0 ? WebDriver.FindElementsByLinkText(linkText)[selectIndex] : WebDriver.FindElementByLinkText(linkText));

        /// <summary>
        /// Finds the elements that match the name supplied with the specified index.
        /// </summary>
        /// <param name="name">Name of the element on the page</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        public IWebElement FindElementByName(string name, int selectIndex = 0)
            => Until((driver) => selectIndex > 0 ? WebDriver.FindElementsByName(name)[selectIndex] : WebDriver.FindElementByName(name));

        /// <summary>
        /// Finds the elements that match the part of the link text supplied with the specified index.
        /// </summary>
        /// <param name="partialLinkText">part of the link text</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        public IWebElement FindElementByPartialLinkText(string partialLinkText, int selectIndex = 0)
            => Until((driver) => selectIndex > 0 ? WebDriver.FindElementsByPartialLinkText(partialLinkText)[selectIndex] : WebDriver.FindElementByPartialLinkText(partialLinkText));

        /// <summary>
        /// Finds the elements that match the DOM Tag supplied with the specified index.
        /// </summary>
        /// <param name="tagName">DOM tag Name of the element being searched</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        public IWebElement FindElementByTagName(string tagName, int selectIndex = 0)
            => Until((driver) => selectIndex > 0 ? WebDriver.FindElementsByTagName(tagName)[selectIndex] : WebDriver.FindElementByTagName(tagName));

        /// <summary>
        /// Finds the elements that match the XPath supplied with the specified index.
        /// </summary>
        /// <param name="xpath">xpath to the element</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        public IWebElement FindElementByXPath(string xpath, int selectIndex = 0)
            => Until((driver) => selectIndex > 0 ? WebDriver.FindElementsByXPath(xpath)[selectIndex] : WebDriver.FindElementByXPath(xpath));

        /// <summary>
        /// Finds the elements on the page by using the OpenQA.Selenium.By object and returns
        ///     a ReadOnlyCollection of the Elements on the page
        /// </summary>
        /// <param name="selector">The selector to find the element</param>
        /// <param name="selectorType">The type of selector</param>
        /// <returns>ReadOnlyCollection of IWebElement</returns>
        public ReadOnlyCollection<IWebElement> FindElements(string selector, SelectorType selectorType = SelectorType.CssSelector)
            => Until((driver) => driver.FindElements(GetBy(selector, selectorType)));

        /// <summary>
        /// Finds a list of elements that match the class name supplied
        /// </summary>
        /// <param name="className">CSS class Name on the element</param>
        /// <returns>ReadOnlyCollection of IWebElement object so that you can interact with those objects</returns>
        public ReadOnlyCollection<IWebElement> FindElementsByClassName(string className)
            => Until((driver) => WebDriver.FindElementsByClassName(className));

        /// <summary>
        /// Finds all elements matching the specified CSS selector.
        /// </summary>
        /// <param name="cssSelector">The CSS selector to match.</param>
        /// <returns>A System.Collections.ObjectModel.ReadOnlyCollection`1 containing all OpenQA.Selenium.IWebElement matching the criteria.</returns>
        public ReadOnlyCollection<IWebElement> FindElementsByCssSelector(string cssSelector)
            => Until((driver) => WebDriver.FindElementsByCssSelector(cssSelector));

        /// <summary>
        /// Finds the first element in the page that matches the ID supplied
        /// </summary>
        /// <param name="id">ID of the Element</param>
        /// <returns>ReadOnlyCollection of Elements that match the object so that you can interact that object</returns>
        public ReadOnlyCollection<IWebElement> FindElementsById(string id)
            => Until((driver) => WebDriver.FindElementsById(id));

        /// <summary>
        /// Finds a list of elements that match the link text supplied
        /// </summary>
        /// <param name="linkText">Link text of element</param>
        /// <returns>ReadOnlyCollection object so that you can interact with those objects</returns>
        public ReadOnlyCollection<IWebElement> FindElementsByLinkText(string linkText)
            => Until((driver) => WebDriver.FindElementsByLinkText(linkText));

        /// <summary>
        /// Finds a list of elements that match the name supplied
        /// </summary>
        /// <param name="name">Name of element</param>
        /// <returns>ReadOnlyCollect of IWebElement objects so that you can interact that object</returns>
        public ReadOnlyCollection<IWebElement> FindElementsByName(string name)
            => Until((driver) => WebDriver.FindElementsByName(name));

        /// <summary>
        /// Finds a list of elements that match the class name supplied
        /// </summary>
        /// <param name="partialLinkText">part of the link text</param>
        /// <returns>ReadOnlyCollection objects so that you can interact that object</returns>
        public ReadOnlyCollection<IWebElement> FindElementsByPartialLinkText(string partialLinkText)
            => Until((driver) => WebDriver.FindElementsByPartialLinkText(partialLinkText));

        /// <summary>
        /// Finds a list of elements that match the DOM Tag supplied
        /// </summary>
        /// <param name="tagName">DOM tag Name of element being searched</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        public ReadOnlyCollection<IWebElement> FindElementsByTagName(string tagName)
            => Until((driver) => WebDriver.FindElementsByTagName(tagName));

        /// <summary>
        /// Finds a list of elements that match the XPath supplied
        /// </summary>
        /// <param name="xpath">xpath to the element</param>
        /// <returns>ReadOnlyCollection of IWebElement objects so that you can interact that object</returns>
        public ReadOnlyCollection<IWebElement> FindElementsByXPath(string xpath)
            => Until((driver) => WebDriver.FindElementsByXPath(xpath));

        /// <summary>
        /// Finds the select element (dropdownlist) matching the specified selector with the specified index.
        /// </summary>
        /// <param name="selector">The selector to match</param>
        /// <param name="selectorType">The selector type</param>
        /// <param name="selectIndex">The index of element that you want to select. Default is 0.</param>
        /// <returns>The OpenQA.Selenium.Support.UI.SelectElement matching the criteria.</returns>
        public SelectElement FindSelectElement(string selector, SelectorType selectorType = SelectorType.CssSelector, int selectIndex = 0)
            => new SelectElement(FindElement(selector, selectorType, selectIndex));
    }
}
