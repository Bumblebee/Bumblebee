using System;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared
{
    public class HeadlessChromeWithNoWaitTime : HeadlessChrome
    {
        public override IWebDriver CreateWebDriver()
        {
            var driver = base.CreateWebDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            return driver;
        }
    }
}