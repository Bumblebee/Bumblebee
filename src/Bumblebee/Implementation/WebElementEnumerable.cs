using System.Collections;
using System.Collections.Generic;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class WebElementEnumerable : IEnumerable<IWebElement>
	{
		private readonly IBlock _parent;
		private readonly By _by;

		public WebElementEnumerable(IBlock parent, By @by)
		{
			_parent = parent;
			_by = @by;
		}

		public IEnumerator<IWebElement> GetEnumerator()
		{
			return _parent.Tag
				.FindElements(_by)
				.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
