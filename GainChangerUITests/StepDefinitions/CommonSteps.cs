using GainChangerUITest.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GainChangerUITest.StepDefinitions
{
    public class CommonSteps : TechTalk.SpecFlow.Steps
    {
        private readonly IWebDriver driver;
        private readonly HomePage homePage;

        public CommonSteps(IWebDriver driver)
        {
            this.driver = driver;
            this.homePage = new HomePage(driver);
        }

        [When(@"User click on the ""(.*)"" menu link")]
        public void WhenUserClickOnTheLink(string linkText)
        {
            this.homePage.NavLink(linkText).Click();
        }
    }
}
