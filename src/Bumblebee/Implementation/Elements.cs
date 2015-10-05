using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Elements<TElement> : IEnumerable<TElement>
		where TElement : IElement
	{
		private readonly IBlock _parent;
		private readonly By _by;

		public Elements(IBlock parent, By @by)
		{
			_parent = parent;
			_by = @by;
		}

		public IEnumerator<TElement> GetEnumerator()
		{
			return _parent
				.FindElements(_by)
				.Select(x => Element.Create<TElement>(_parent, x))
				.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
