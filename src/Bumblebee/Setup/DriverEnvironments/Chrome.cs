using System;
using OpenQA.Selenium.Chrome;

namespace Bumblebee.Setup.DriverEnvironments
{
	public class Chrome : SimpleDriverEnvironment<ChromeDriver>
	{
		public Chrome()
		{
		}

		public Chrome(TimeSpan timeToWait) : base(timeToWait)
		{
			var driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), new ChromeOptions(), TimeSpan.FromMinutes(1));


		}
	}
}
