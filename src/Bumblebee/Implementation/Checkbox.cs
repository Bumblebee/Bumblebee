using System;

using Bumblebee.Extensions;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Checkbox : Element, ICheckbox
	{
		public Checkbox(IBlock parent, By @by, TimeSpan? timeout = null)
			: base(parent, @by, timeout)
		{
		}

		public TResult Check<TResult>() where TResult : IBlock
		{
			if (Selected == false)
			{
				Tag.Click();
			}

			return this.FindRelated<TResult>();
		}

		public TResult Uncheck<TResult>() where TResult : IBlock
		{
			if (Selected)
			{
				Tag.Click();
			}

			return this.FindRelated<TResult>();
		}

		public TResult Toggle<TResult>() where TResult : IBlock
		{
			Tag.Click();

			return this.FindRelated<TResult>();
		}
	}

	public class Checkbox<TResult> : Checkbox, ICheckbox<TResult>
		where TResult : IBlock
	{
		public Checkbox(IBlock parent, By @by, TimeSpan? timeout = null) 
			: base(parent, @by, timeout)
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
