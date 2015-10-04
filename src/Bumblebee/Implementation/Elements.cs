using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Elements<T> : IEnumerable<T>
		where T : IElement
	{
		private readonly IBlock _parent;
		private readonly By _by;

		public Elements(IBlock parent, By @by)
		{
			_parent = parent;
			_by = @by;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _parent
				.FindElements(_by)
				.Select(x => Factory.CreateElementFromParentAndElement<T>(_parent, x))
				.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
