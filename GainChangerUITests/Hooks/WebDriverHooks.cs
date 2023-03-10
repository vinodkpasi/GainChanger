using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace GainChangerUITest.Hooks
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly IObjectContainer container;

        public WebDriverHooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            string driverPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Drivers");
            ChromeDriver driver = new ChromeDriver(driverPath);
            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario(Order = 2)]
        public void DestroyWebDriver()
        {
            
            var driver = container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
