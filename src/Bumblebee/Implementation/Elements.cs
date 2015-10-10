using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;
using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Elements<TElement> : IEnumerable<TElement>
		where TElement : IElement
	{
		private readonly IBlock _parent;
		private readonly By _by;
		private readonly TimeSpan? _timeout;

		public Elements(IBlock parent, By @by)
		{
			_parent = parent;
			_by = @by;
		}

		public Elements(IBlock parent, By @by, TimeSpan timeout)
		{
			_parent = parent;
			_by = @by;
			_timeout = timeout;
		}

		public IEnumerator<TElement> GetEnumerator()
		{
			return _parent
				.FindElements(_by)
				.Select((element, index) => 
					_timeout.HasValue
						? Element.Create<TElement>(_parent, new ByOrdinal(_by, index), _timeout.Value)
						: Element.Create<TElement>(_parent, new ByOrdinal(_by, index)))
				.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
