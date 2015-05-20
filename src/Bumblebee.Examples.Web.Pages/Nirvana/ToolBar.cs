using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class ToolBar : Block
	{
		public ToolBar(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public ITextField<ToolBar> SearchField
		{
			get { return new TextField<ToolBar>(this, By.ClassName("q")); }
		}

		public IClickable<NewTaskForm> NewTask
		{
			get { return new Clickable<NewTaskForm>(this, By.ClassName("newtask")); }
		}

		public IHasText Account
		{
			get { return new TextField(this, By.CssSelector("a.right.button.accountmenu.xcmenu")); }
		}
	}
}
