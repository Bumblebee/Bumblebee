using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class TextFieldPage : WebPage
	{
		public TextFieldPage(Session session) : base(session)
		{
		}

		public ITextField<TextFieldPage> Text
		{
			get { return new TextField<TextFieldPage>(this, By.Id("TextField")); }
		}
	}
}
