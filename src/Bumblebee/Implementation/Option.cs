using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Option : Element, IOption
	{
		public Option(IBlock parent, By by) : base(parent, @by)
		{
		}

		public Option(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

		public virtual TResult Click<TResult>() where TResult : IBlock
		{
			ParentBlock.Tag.Click();

			Tag.Click();

			return FindRelated<TResult>();
		}
	}

	public class Option<TResult> : Option, IOption<TResult> where TResult : IBlock
	{
		public Option(IBlock parent, By by) : base(parent, @by)
		{
		}

		public Option(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

		public virtual TResult Click()
		{
			return Click<TResult>();
		}
	}
}