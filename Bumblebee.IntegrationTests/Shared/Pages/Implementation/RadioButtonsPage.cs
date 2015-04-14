using System;

using Bumblebee.Implementation;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class RadioButtonsPage : WebBlock
	{
		public RadioButtonsPage(Session session, TimeSpan timeout) : base(session, timeout)
		{
		}

		public RadioButtonsPage(Session session) : base(session)
		{
		}

		public RadioButtons<RadioButtonsPage> Beverages
		{
			get { return new RadioButtons<RadioButtonsPage>(this, By.Name("beverages")); }
		}
	}
}
