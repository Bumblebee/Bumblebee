using OpenQA.Selenium;

namespace Bumblebee
{
    public interface IDriverEnvironment
    {
        IWebDriver CreateWebDriver();
    }
}