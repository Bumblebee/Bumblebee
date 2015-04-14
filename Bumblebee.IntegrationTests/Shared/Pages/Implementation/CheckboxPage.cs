using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class CheckboxPage : WebBlock
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
