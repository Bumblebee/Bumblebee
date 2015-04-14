using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class NumericFieldPage : WebBlock
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
