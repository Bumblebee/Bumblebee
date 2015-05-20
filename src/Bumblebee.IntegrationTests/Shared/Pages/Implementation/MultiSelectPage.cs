using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class MultiSelectPage : WebBlock
	{
		public MultiSelectPage(Session session) : base(session)
		{
		}

		public ISelectBox<MultiSelectPage> Toppings
		{
			get { return new SelectBox<MultiSelectPage>(this, By.Id("MultiSelectBox")); }
		}
	}
}
