using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GainChangerUITest.Pages
{
    public class HomePage : BasePage
    {

        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement NavLink(string linkText)
        {
            IWebElement ele = this.Driver.FindElement(By.XPath("(//a[text()='" + linkText + "'])/.."));
            return ele;
        }
    }
}
