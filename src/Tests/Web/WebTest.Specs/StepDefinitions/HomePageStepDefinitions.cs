using WebTest.Specs.Pages;

namespace WebTest.Specs.StepDefinitions
{
    [Binding]
    public class HomePageStepDefinitions
    {
        private readonly GooglePages _page;
        FeatureContext _scenarioContext;

        public HomePageStepDefinitions(GooglePages page, FeatureContext scenarioContext)
        {
            _page = page;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I go to ""([^""]*)""")]
        public void GivenIGoTo(string url)
        {
            _page.HomePage.GoHere();
        }

        [When(@"The page has been loaded successfully")]
        public void WhenThePageHasBeenLoadedSuccessfully()
        {
            _page.HomePage.IsDisplaying();
        }

        [Then(@"I can see the ""([^""]*)"" as the title")]
        public void ThenICanSeeTheAsTheTitle(string google)
        {
            var rsl = _page.HomePage.IsDisplaying();
            if (_scenarioContext.Get<string>("browserId") == "Chrome")
            {
                //rsl.Should().BeFalse();
            }
            rsl.Should().BeTrue();
        }
    }
}
