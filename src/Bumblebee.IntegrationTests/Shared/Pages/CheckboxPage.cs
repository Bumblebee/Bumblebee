using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class CheckboxPage : WebPage
	{
		public CheckboxPage(Session session) : base(session)
		{
		}

		public ICheckbox<CheckboxPage> CheckedCheckbox
		{
			get { return new Checkbox<CheckboxPage>(this, By.Id("CheckedCheckbox")); }
		}

		public ICheckbox<CheckboxPage> UncheckedCheckbox
		{
			get { return new Checkbox<CheckboxPage>(this, By.Id("UncheckedCheckbox")); }
		}
	}
}
