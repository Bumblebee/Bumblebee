using System;

using OpenQA.Selenium.IE;

namespace Bumblebee.Setup.DriverEnvironments
{
	public class InternetExplorer : SimpleDriverEnvironment<InternetExplorerDriver>
	{
		public InternetExplorer()
		{
		}

		public InternetExplorer(TimeSpan timeToWait) : base(timeToWait)
		{
		}
	}
}
