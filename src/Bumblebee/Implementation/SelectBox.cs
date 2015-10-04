using System.Collections.Generic;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class SelectBox : Block, ISelectBox
	{
		public SelectBox(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public virtual IEnumerable<IOption> Options
		{
			get { return FindElements<Option>(By.TagName("option")); }
		}
	}

	public class SelectBox<TResult> : SelectBox, ISelectBox<TResult>
		where TResult : IBlock
	{
		public SelectBox(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public virtual IEnumerable<IOption<TResult>> Options
		{
			get { return FindElements<Option<TResult>>(By.TagName("option")); }
		}
	}
}
