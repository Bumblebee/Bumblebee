using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class LoggedInPage : WebBlock
	{
		public LoggedInPage(Session session) : base(session)
		{
		}

		public ToolBar ToolBar
		{
			get { return new ToolBar(this, By.Id("north")); }
		}

		public SideBar SideBar
		{
			get { return new SideBar(this, By.Id("east")); }
		}

		public MainArea MainArea
		{
			get { return new MainArea(this, By.Id("main")); }
		}

		public NewTaskForm NewTaskForm
		{
			get { return new NewTaskForm(this, By.ClassName("promptnewtask"));}
		}
	}
}
