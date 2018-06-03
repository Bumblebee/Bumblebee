using Bumblebee.Setup;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Bumblebee.IntegrationTests.Shared
{
    public class HeadlessChrome : IDriverEnvironment
    {
        public virtual IWebDriver CreateWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");

            var driver = new ChromeDriver(options);
            return driver;
        }
    }
}
