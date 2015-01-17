using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace Bumblebee.IntegrationTests.Bumblebee.Setup
{
    [TestFixture(typeof(Firefox), typeof(FirefoxDriver))]
    [TestFixture(typeof(InternetExplorer), typeof(InternetExplorerDriver))]
    [TestFixture(typeof(Chrome), typeof(ChromeDriver))]
    [TestFixture(typeof(PhantomJS), typeof(PhantomJSDriver))]
    public class DriverEnvironmentTests<TDriverEnvironment, TExpectedDriver>
        where TDriverEnvironment : IDriverEnvironment, new()
        where TExpectedDriver : IWebDriver
    {
        [Test]
        public void given_driver_environment_when_creating_web_driver_should_be_correct_type()
        {
            var environment = new TDriverEnvironment();
            var driver = environment.CreateWebDriver();
            
            driver.Should().BeOfType<TExpectedDriver>();
            
            driver.Close();
            driver.Quit();
        }
    }
}
