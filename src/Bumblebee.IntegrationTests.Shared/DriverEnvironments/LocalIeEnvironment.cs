using System;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace Bumblebee.IntegrationTests.Shared.DriverEnvironments
{
    public class LocalIeEnvironment : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            return driver;
        }
    }
}