using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bumblebee.Setup;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Bumblebee.IntegrationTests.Shared.DriverEnvironments
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
