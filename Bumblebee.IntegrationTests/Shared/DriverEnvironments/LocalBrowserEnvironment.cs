using System;

using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.DriverEnvironments
{
    public class LocalBrowserEnvironment<T> : IDriverEnvironment
        where T : IWebDriver, new()
    {
        public IWebDriver CreateWebDriver()
        {
            var result = new T();

            result.Manage().Window.Maximize();
            result.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            return result;
        }
    }
}
