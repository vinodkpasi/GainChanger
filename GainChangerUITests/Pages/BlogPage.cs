using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace GainChangerUITest.Pages
{
    public class BlogPage : BasePage
    {

        public BlogPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.CssSelector, Using = ".elementor-post__card>a")]
        public IWebElement FirstBlog;

        [FindsBy(How = How.TagName, Using = "h1")]
        public IList<IWebElement> Headers1;

        [FindsBy(How = How.TagName, Using = "h2")]
        public IList<IWebElement> Headers2;

        [FindsBy(How = How.CssSelector, Using = "meta[property*='title']")]
        public IWebElement MetaTitle;

        [FindsBy(How = How.CssSelector, Using = "meta[property*='description']")]
        public IWebElement MetaDescription;

        [FindsBy(How = How.CssSelector, Using = "div>p")]
        public IList<IWebElement> Paragraphs;
        
        public void OpenFirstBlog()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].click()", FirstBlog);
        }
    }
}
