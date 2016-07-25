using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class HundredThousandItemSelectPage : Page
	{
		public HundredThousandItemSelectPage(Session session) : base(session)
		{
		}

		public ISelectBox<HundredThousandItemSelectPage> SelectBox
		{
			get { return new SelectBox<HundredThousandItemSelectPage>(this, By.Id("HundredThousandItemSelect")); }
		}
	}
}
