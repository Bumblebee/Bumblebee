using OpenQA.Selenium;

namespace Bumblebee.Setup
{
	public interface IDriverEnvironment
	{
		IWebDriver CreateWebDriver();
	}
}
