using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace WooliesXUIAutomation.StepDefinition
{
    [Binding]
    class AbstractBaseStep
    {
        protected static IWebDriver driver;
        protected static WebDriverWait Wait;

        [BeforeTestRun]
        public static IWebDriver setDriver()
        {
            if (driver == null)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--no-sandbox"); // Bypass OS security model, MUST BE THE VERY FIRST OPTION
                options.AddArgument("--disable-gpu"); // applicable to windows os only
                options.AddArgument("start-maximized");
                options.AddArgument("enable-automation");
                options.PageLoadStrategy = PageLoadStrategy.Normal;
                driver = new ChromeDriver(options);
                Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));

            }
            driver.Manage().Window.Maximize();

            return driver;
        }

        [AfterTestRun]
        public static void tearDown()
        {
            driver.Quit();
        }

        [AfterStep]
        public void TakeScreenshotAfterStep()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                try
                {
                    ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                    if (takesScreenshot != null)
                    {
                        var screenshot = takesScreenshot.GetScreenshot();

                        string screenshotFilePath = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                        screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

                        Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while taking screenshot: {0}", ex);
                }
            }
        }
    }
}
