using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class TaskRow : Block
	{
		public TaskRow(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public string Name
		{
			get { return GetElement(By.CssSelector("span.name.edittask")).Text; }
		}

		public IClickable<TaskRow> Complete
		{
			get { return new Clickable<TaskRow>(this, By.CssSelector("span.i.check")); }
		}

		public void Delete()
		{
			var drag = GetElement(By.CssSelector("span.i.drag.project"));

			var sidebar = FindRelated<SideBar>();

			var drop = sidebar.Trash;

			GetDragAndDropPerformer()
				.DragAndDrop(drag, drop.Tag);

			Session.Pause(200);
		}
	}
}
