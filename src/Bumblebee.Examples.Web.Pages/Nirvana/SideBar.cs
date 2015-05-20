using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class SideBar : Block
	{
		public SideBar(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public IClickable Trash
		{
			get { return new Clickable(this, By.CssSelector("li.trash")); }
		}
	}
}
