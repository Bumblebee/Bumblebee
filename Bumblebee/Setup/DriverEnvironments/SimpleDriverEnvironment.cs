using OpenQA.Selenium;

namespace Bumblebee.Setup.DriverEnvironments
{
    public abstract class SimpleDriverEnvironment<TWebDriver> : IDriverEnvironment
        where TWebDriver : IWebDriver, new()
    {
        public IWebDriver CreateWebDriver()
        {
            return new TWebDriver();
        }
    }
}