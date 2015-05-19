using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class DateFieldPage : WebBlock
	{
		public DateFieldPage(Session session)
			: base(session)
		{
		}

		public IDateField<DateFieldPage> Date
		{
			get { return new DateField<DateFieldPage>(this, By.Id("DateField")); }
		}
	}
}
