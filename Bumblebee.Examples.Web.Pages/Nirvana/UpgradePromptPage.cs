using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class UpgradePromptPage : WebBlock
	{
		public UpgradePromptPage(Session session) : base(session)
		{
		}

		public IClickable<LoggedInPage> NotNow
		{
			get { return new Clickable<LoggedInPage>(this, By.CssSelector("a.button.notnow")); }
		}
	}
}
