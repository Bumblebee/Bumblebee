using System;

using Bumblebee.Extensions;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Option : Element, IOption
	{
		public Option(IBlock parent, By by, TimeSpan? timeout = null)
			: base(parent, @by, timeout)
		{
		}

		public virtual TResult Click<TResult>() where TResult : IBlock
		{
			Parent.Tag.Click();

			Tag.Click();

			return this.FindRelated<TResult>();
		}
	}

	public class Option<TResult> : Option, IOption<TResult>
		where TResult : IBlock
	{
		public Option(IBlock parent, By by, TimeSpan? timeout = null)
			: base(parent, @by, timeout)
		{
		}

		public virtual TResult Click()
		{
			return Click<TResult>();
		}
	}
}
