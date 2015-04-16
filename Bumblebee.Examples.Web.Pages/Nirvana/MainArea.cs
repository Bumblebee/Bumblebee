using System.Collections.Generic;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class MainArea : Block
	{
		public MainArea(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public IEnumerable<TaskList> TaskLists
		{
			get { return new BlockEnumerable<TaskList>(this, By.ClassName("tasklist")); }
		}
	}
}
