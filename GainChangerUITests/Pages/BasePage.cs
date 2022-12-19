using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace GainChangerUITest.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            this.Driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
        }

        protected void VerifyPageLoaded(By by, uint time = 30)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

    }
}
