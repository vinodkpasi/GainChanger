using BoDi;
using GainChangerUITests.Utils;
using OpenQA.Selenium;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace GainChangerUITest.Hooks
{
    [Binding]
    public class ScreenshotHooks
    {
        private readonly IObjectContainer container;

        public ScreenshotHooks(IObjectContainer container)
        {
            this.container = container;
        }

        [AfterScenario(Order =1)]
        public void ScreenshotWebDriver()
        {

            var driver = container.Resolve<IWebDriver>();
            if (ScenarioContext.Current.TestError != null)
            {
                TakeScreenshot(driver);
            }
        }

        private void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = string.Format("Error_{0}_{1}_{2}",
                                                    FeatureContext.Current.FeatureInfo.Title,
                                                    ScenarioContext.Current.ScenarioInfo.Title,
                                                    DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");

                var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();
                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase);
                    screenshot.SaveAsFile(screenshotFilePath, System.Drawing.Imaging.ImageFormat.Png);
                    Console.WriteLine("<a href='{0}' target='_blank'>Screenshot</a>", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
                Util.Log.Error(ex.StackTrace);
            }
        }
    }
}
