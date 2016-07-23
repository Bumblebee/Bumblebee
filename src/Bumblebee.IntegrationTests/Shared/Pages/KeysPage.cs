using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class KeysPage : WebPage
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
				return FindElement(By.Id("KeyPressed")).Text;
			}
		}
	}
}
