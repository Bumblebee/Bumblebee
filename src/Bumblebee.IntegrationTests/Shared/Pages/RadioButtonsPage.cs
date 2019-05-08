using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class RadioButtonsPage : Page
	{
		public RadioButtonsPage(Session session, TimeSpan timeout) : base(session, timeout)
		{
		}

		public RadioButtonsPage(Session session) : base(session)
		{
		}

		public IRadioButtons<RadioButtonsPage> Beverages
		{
			get { return new RadioButtons<RadioButtonsPage>(this, By.Name("beverages")); }
		}
	}
}
