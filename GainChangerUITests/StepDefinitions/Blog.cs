using GainChangerUITest.Pages;
using GainChangerUITests.Entities;
using GainChangerUITests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GainChangerUITest.StepDefinitions
{
    [Binding]
    public class BlogSteps : CommonSteps
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;
        private readonly BlogPage blogPage;

        public BlogSteps(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.loginPage = new LoginPage(driver);
            this.blogPage = new BlogPage(driver);

        }

        [Given(@"User navigate to login page")]
        public void GivenUserNavigateToLoginPage()
        {
            loginPage.Navigate();
            Util.Log.Info("Navigated to the url.");
        }

        [When(@"User enter ""(.*)"" as username")]
        public void WhenUserEnterAsUsername(string username)
        {
            loginPage.EnterUsername(username);
        }

        [When(@"User enter ""(.*)"" as password")]
        public void WhenUserEnterAsPassword(string password)
        {
            loginPage.EnterPassword(password);
        }

        [When(@"User click on the Login button")]
        public void WhenUserClickOnTheLoginButton()
        {
            loginPage.Submit();
        }

        [Then(@"User should be able to see the home page")]
        public void ThenUserShouldBeAbleToSeeTheHomePage()
        {

            Assert.IsTrue(driver.Title.Contains("GainChanger: SEO Services, Audits, Content"));
        }

        [Then(@"User should be able to see the blog page")]
        public void ThenUserShouldBeAbleToSeeTheBlogPage()
        {
            Assert.IsTrue(driver.Title.Contains("GainChanger Blog"));
        }

        [When(@"User open the first blog")]
        public void WhenUserOpenTheFirstBlog()
        {
            blogPage.OpenFirstBlog();
            System.Threading.Thread.Sleep(3000);
        }

        [Then(@"User should be able to see the blog details and save in json file")]
        public void ThenUserShouldBeAbleToSeeTheBlogDetailsAndSaveInJsonFile()
         {
            Blog blog = new Blog();
            blog.MetaTitle = blogPage.MetaTitle.GetAttribute("content");
            blog.MetaDescription = blogPage.MetaDescription.GetAttribute("content");
            blog.Headers1 = Util.GetAllElementsText(blogPage.Headers1);
            blog.Headers2 = Util.GetAllElementsText(blogPage.Headers2);
            blog.Paragraphs = Util.GetAllElementsText(blogPage.Paragraphs);
            Util.ExportInJsonFile(blog, "D://blog.json");
        }
    }
}
