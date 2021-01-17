using System;
using OpenQA.Selenium;
using WooliesXUIAutomation.Utilities;

namespace WooliesXUIAutomation.Pages
{
    class AbstractPage
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWrapper wrapper;

        public AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
            wrapper = new WebDriverWrapper(this.driver);
        }
    }
}
