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
			get { return new ElementEnumerable<Option>(this, By.TagName("option")); }
		}
	}

	public class SelectBox<TResult> : Block, ISelectBox<TResult> where TResult : IBlock
	{
		public SelectBox(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public virtual IEnumerable<IOption<TResult>> Options
		{
			get { return new ElementEnumerable<Option<TResult>>(this, By.TagName("option")); }
		}
	}
}
