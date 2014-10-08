using System;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace Bumblebee.Examples.Web.IntegrationTests.Infrastructure
{
    public class LocalPhantomJsEnvironment : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var driver = new PhantomJSDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            return driver;
        }
    }
}