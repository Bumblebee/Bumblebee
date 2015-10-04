using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class NumericFieldPage : WebPage
	{
		public NumericFieldPage(Session session) : base(session)
		{
		}

		public INumericField<NumericFieldPage> Number
		{
			get { return new NumericField<NumericFieldPage>(this, By.Id("NumericField")); }
		}
	}
}
