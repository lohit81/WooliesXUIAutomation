using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;


namespace WooliesXUIAutomation.Utilities
{
    class WebDriverWrapper
    {
        private readonly IWebDriver driver;

        public WebDriverWrapper(IWebDriver currentDriver)
        {
            driver = currentDriver;
        }

        public IWebElement findElement(By elementLocator, int timeOutInSeconds)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                return wait.Until<IWebElement>((currentDriver) => currentDriver.FindElement(elementLocator));
            }
            return driver.FindElement(elementLocator);
        }

        public static ReadOnlyCollection<IWebElement> FindElements(IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(currentDriver => (currentDriver.FindElements(by).Count > 0) ? currentDriver.FindElements(by) : null);
            }
            else
            {
                return driver.FindElements(by);
            }
        }

        public void sendKeys(By elementLocator, string textToSend, int timeOutInseconds)
        {
            findElement(elementLocator, timeOutInseconds).SendKeys(textToSend);
        }

        public void clickElement(By elementLocator, int timeOutInseconds)
        {
            findElement(elementLocator, timeOutInseconds).Click();
        }

        public void selectItem(By elementLocator, int indexValue)
        {
            SelectElement objSelect = new SelectElement(driver.FindElement(elementLocator));
            objSelect.SelectByIndex(indexValue); // Select index value
        }

            

    }
}
