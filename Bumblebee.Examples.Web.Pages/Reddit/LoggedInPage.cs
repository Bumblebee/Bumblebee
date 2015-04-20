using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Reddit
{
	public class LoggedInPage : RedditPage
	{
		public LoggedInPage(Session session) : base(session)
		{
			// Wait until we're logged in, then reselect the body to keep the DOM fresh
			Wait.Until(driver => driver.FindElement(By.CssSelector(".user a")));
			Tag = Session.Driver.FindElement(By.TagName("body"));
		}

		public IClickable<WebBlock> Profile
		{
			get { return new Clickable<WebBlock>(this, By.CssSelector(".user a")); }
		}

		public IClickable<LoggedOutPage> Logout
		{
			get { return new Clickable<LoggedOutPage>(this, By.LinkText("logout")); }
		}
	}
}
