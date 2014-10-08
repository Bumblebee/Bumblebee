using System;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Bumblebee.Examples.Web.IntegrationTests.Infrastructure
{
    public class LocalChromeEnvironment : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            return driver;
        }
    }
}
