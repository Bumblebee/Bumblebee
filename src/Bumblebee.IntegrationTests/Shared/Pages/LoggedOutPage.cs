using Bumblebee.Implementation;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class LoggedOutPage : Block
	{
		public LoggedOutPage(Session session) : base(session, By.Id("login"))
		{
		}
	}
}
