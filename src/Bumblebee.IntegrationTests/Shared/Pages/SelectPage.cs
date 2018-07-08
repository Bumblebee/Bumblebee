using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class SelectPage : Page
	{
		public SelectPage(Session session) : base(session)
		{
		}

		public ISelectBox<SelectPage> Toppings
		{
			get { return new SelectBox<SelectPage>(this, By.Id("SelectBox")); }
		}
	}
}
