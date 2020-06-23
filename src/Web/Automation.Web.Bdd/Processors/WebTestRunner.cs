using Automation.Web.Bdd.Logger;
using Automation.Web.Bdd.Models;
using Automation.Web.Core;
using Automation.Web.Core.Config;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Action = Automation.Web.Bdd.Models.Action;

namespace Automation.Web.Bdd.Processors
{
    public class WebTestRunner : IWebTestRunner
    {
        protected IBrowser Browser;
        protected TestStatus TestResult;
        protected ILogger logger;

        public WebTestRunner(BrowserConfig browserConfig)
        {
            Browser = BrowserFactory.CreateBrowser(browserConfig);
            logger = new BddLogger(browserConfig.Browser.ToString());
        }

        public void Run(Step[] steps)
        {
            logger.Log($"Start browser {Browser.BrowserType}.");
            try
            {
                steps = steps.OrderBy(x => x.Order).ToArray();

                foreach (var step in steps)
                {
                    RunAsync(step);
                }

                TestResult = TestStatus.Passed;
                logger.Log("Successed!");
            }
            catch(Exception ex)
            {
                logger.Log("Failed!");
                logger.Log(ex.Message);
                logger.LogError(ex.Message);
                TestResult = TestStatus.Failed;
            }

            logger.Export();
            Browser.Quit();
        }

        protected void RunAsync(Step step)
        {
            switch (step.Action)
            {
                case Action.Assert:
                    RunAssert(step);
                    break;

                case Action.Click:
                    RunClick(step);
                    break;

                case Action.Enter:
                    RunEnter(step);
                    break;

                case Action.MouseOver:
                    RunMouseOver(step);
                    break;

                case Action.Redirect:
                    RunRedirect(step);
                    break;

                case Action.Scroll:
                    RunScroll(step);
                    break;

                case Action.SelectCheckBox:
                    RunSelectCheckBox(step);
                    break;

                case Action.SelectDropdownList:
                    RunSelectDropdownList(step);
                    break;

                case Action.SelectRadio:
                    RunSelectRadio(step);
                    break;

                case Action.Wait:
                    RunWait(step);
                    break;

                default:
                    throw new InvalidEnumArgumentException($"The action {step.Action} isn't supported.");
            }
        }

        protected void RunAssert(Step step)
        {
            switch (step.SelectorType)
            {
                case SelectorType.Title:
                    AssertTitle(step);
                    break;

                case SelectorType.Url:
                    AssertUrl(step);
                    break;

                default:
                    AssertElement(step);
                    break;
            }
        }

        protected void AssertTitle(Step step)
        {
            switch (step.AssertCondition)
            {
                case AssertCondition.Contains:
                    Browser.WaitUntilTitleContains(step.Value);
                    break;

                case AssertCondition.Equals:
                    Browser.WaitUntilTitleIs(step.Value);
                    break;
            }
        }

        protected void AssertUrl(Step step)
        {
            switch (step.AssertCondition)
            {
                case AssertCondition.Contains:
                    Browser.WaitUntilUrlContains(step.Value);
                    break;

                case AssertCondition.Equals:
                    Browser.WaitUntilUrlToBe(step.Value);
                    break;
            }
        }

        protected void AssertElement(Step step)
        {
            switch (step.AssertCondition)
            {
                case AssertCondition.Displays:
                    Browser.WaitUntilElementIsVisible(step.Selector, step.SelectorType);
                    break;

                case AssertCondition.Contains:
                    Browser.WaitUntilTextToBePresentInElement(step.Selector, step.Value, step.SelectorType);
                    break;

                case AssertCondition.Equals:
                    var result = Browser.FindElement(step.Selector, step.SelectorType).Text;
                    if (!string.Equals(result, step.Value, StringComparison.OrdinalIgnoreCase))
                        throw new InvalidDataException($"Excepted result is {step.Value}, but actual value is {result}.");
                    break;
            }
        }

        protected void RunClick(Step step)
        {
            logger.Log($"Click the {step.DisplayName}.");
            var element = Browser.FindElement(step.Selector, step.SelectorType);
            element.Click();
        }

        protected void RunEnter(Step step)
        {
            logger.Log($"Enter {step.Value} to the {step.DisplayName}.");
            var element = Browser.FindElement(step.Selector, step.SelectorType);
            element.SendKeys(step.Value);
        }

        protected void RunMouseOver(Step step)
        {
            logger.Log($"Mouse over the {step.DisplayName}.");
            var element = Browser.FindElement(step.Selector, step.SelectorType);
            Browser.MouseOverTo(element);
        }

        protected void RunRedirect(Step step)
        {
            logger.Log($"Redirect to the {step.Value}.");
            Browser.Navigation.GoToUrl(step.Value);
        }

        protected void RunScroll(Step step)
        {
            logger.Log($"Scroll to the {step.DisplayName}");
            var element = Browser.FindElement(step.Selector, step.SelectorType);
            Browser.ScrollTo(element);
        }

        protected void RunSelectCheckBox(Step step)
        {

        }

        protected void RunSelectDropdownList(Step step)
        {

        }

        protected void RunSelectRadio(Step step)
        {

        }

        protected void RunWait(Step step)
        {
            logger.Log($"Wait until the {step.DisplayName} displays.");
            Browser.WaitUntilElementIsVisible(step.Selector, step.SelectorType);
        }

        protected string TakeScreenshot(string fileName = null)
        {
            return Browser.TakeAndSaveScreenshot(fileName);
        }
    }
}
