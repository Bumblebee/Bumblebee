using System;

using OpenQA.Selenium;

namespace Bumblebee.Specifications
{
	public static class ByExtensions
	{
		public static By WaitingUntil(this By @by, TimeSpan timeout)
		{
			return new ByWithWait(@by, timeout);
		}
	}
}
