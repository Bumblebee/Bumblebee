using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.KendoUI.IntegrationTests.Pages
{
	public class KendoDatePickerDemoPage : WebBlock
	{
		public KendoDatePickerDemoPage(Session session) : base(session, TimeSpan.FromSeconds(10))
		{
		}

		public IDateField<KendoDatePickerDemoPage> DateFrom
		{
			get { return new KendoDatePicker<KendoDatePickerDemoPage>(this, By.Id("datepicker")); }
		}
	}
}
