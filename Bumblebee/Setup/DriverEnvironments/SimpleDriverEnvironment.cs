using System;

using OpenQA.Selenium;

namespace Bumblebee.Setup.DriverEnvironments
{
	public abstract class SimpleDriverEnvironment<TWebDriver> : IDriverEnvironment
		where TWebDriver : IWebDriver, new()
	{
		private TimeSpan TimeToWait { get; set; }

		public SimpleDriverEnvironment() : this(TimeSpan.FromSeconds(5))
		{
		}

		public SimpleDriverEnvironment(TimeSpan timeToWait)
		{
			TimeToWait = timeToWait;
		}

		public virtual IWebDriver CreateWebDriver()
		{
			var driver = new TWebDriver();

			driver.Manage().Window.Maximize();

			driver.Manage().Timeouts().ImplicitlyWait(TimeToWait);
			
			return driver;
		}
	}
}
