using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class ElementEnumerable<T> : IEnumerable<T>
		where T : IElement
	{
		private static T CreateInstance(IBlock parent, IWebElement tag)
		{
			return (T) Activator.CreateInstance(typeof(T), parent, tag);
		}

		private readonly IBlock _parent;
		private readonly By _by;

		public ElementEnumerable(IBlock parent, By @by)
		{
			_parent = parent;
			_by = @by;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _parent.Tag
				.FindElements(_by)
				.Select(x => CreateInstance(_parent, x))
				.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
