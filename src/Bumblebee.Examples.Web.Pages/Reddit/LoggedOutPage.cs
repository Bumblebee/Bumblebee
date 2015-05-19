using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Reddit
{
	public class LoggedOutPage : RedditPage
	{
		public LoggedOutPage(Session session) : base(session)
		{
		}

		public LoginArea LoginArea
		{
			get { return new LoginArea(Session); }
		}
	}

	public class LoginArea : WebBlock
	{
		public LoginArea(Session session) : base(session)
		{
			Tag = GetElement(By.Id("login_login-main"));
		}

		public ITextField<LoginArea> Email
		{
			get { return new TextField<LoginArea>(this, By.Name("user")); }
		}

		public ITextField<LoginArea> Password
		{
			get { return new TextField<LoginArea>(this, By.Name("passwd")); }
		}

		public IClickable<LoggedInPage> LoginButton
		{
			get { return new Clickable<LoggedInPage>(this, By.TagName("button")); }
		}
	}
}
