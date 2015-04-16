using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class NewTaskForm : Block
	{
		public NewTaskForm(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public ITextField<NewTaskForm> Name
		{
			get { return new TextField<NewTaskForm>(this, By.Name("name")); }
		}

		public ITextField<NewTaskForm> Note
		{
			get { return new TextField<NewTaskForm>(this, By.ClassName("note")); }
		}

		public IClickable<MainArea> Save
		{
			get { return new Clickable<MainArea>(this, By.ClassName("save")); }
		}

		public IClickable<MainArea> Cancel
		{
			get { return new Clickable<MainArea>(this, By.ClassName("cancel")); }
		}
	}
}
