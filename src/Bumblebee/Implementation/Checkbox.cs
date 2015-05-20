using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Checkbox : Element, ICheckbox
	{
		public Checkbox(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public Checkbox(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		public TResult Check<TResult>() where TResult : IBlock
		{
			if (Selected == false)
			{
				Tag.Click();
			}

			return FindRelated<TResult>();
		}

		public TResult Uncheck<TResult>() where TResult : IBlock
		{
			if (Selected)
			{
				Tag.Click();
			}

			return FindRelated<TResult>();
		}

		public TResult Toggle<TResult>() where TResult : IBlock
		{
			Tag.Click();

			return FindRelated<TResult>();
		}
	}

	public class Checkbox<TResult> : Checkbox, ICheckbox<TResult> where TResult : IBlock
	{
		public Checkbox(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public Checkbox(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

		public virtual TResult Check()
		{
			return Check<TResult>();
		}

		public virtual TResult Uncheck()
		{
			return Uncheck<TResult>();
		}

		public virtual TResult Toggle()
		{
			return Toggle<TResult>();
		}
	}
}
