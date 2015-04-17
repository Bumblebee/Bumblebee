using System.Collections.Generic;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class TaskList : Block
	{
		public TaskList(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public string Name
		{
			get { return FindElement(By.ClassName("name")).Text; }
		}

		public IEnumerable<TaskRow> TaskRows
		{
			get { return new BlockEnumerable<TaskRow>(this, By.CssSelector(".tasks .task")); }
		}
	}
}
