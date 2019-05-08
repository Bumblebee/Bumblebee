using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class DateFieldPage : Page
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
