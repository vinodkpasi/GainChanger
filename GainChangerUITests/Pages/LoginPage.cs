using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GainChangerUITest.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement txtUsername;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement txtPassword;


        [FindsBy(How = How.Id, Using = "submit")]
        public IWebElement btnLogin;


        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterUsername(string username)
        {
            txtUsername.Clear();
            txtUsername.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            txtPassword.Clear();
            txtPassword.SendKeys(password);
        }

        public void Submit()
        {
            btnLogin.Click();
        }

        public void Navigate()
        {
            Driver.Url = System.Configuration.ConfigurationManager.AppSettings["baseUrl"];
            string header = Driver.FindElement(By.TagName("h2")).Text;
            Assert.AreEqual("Login To Your Account", header);
        }
    }
}
