using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class KeysPage : WebBlock
	{
		public KeysPage(Session session) : base(session)
		{
		}

		public ITextField<KeysPage> KeysText
		{
			get
			{
				return new TextField<KeysPage>(this, By.Id("KeysTextArea"));
			}
		}

		public string KeyPressed
		{
			get
			{
				return GetElement(By.Id("KeyPressed")).Text;
			}
		}
	}
}
