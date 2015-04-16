using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class BlockEnumerable<T> : IEnumerable<T>
		where T : IBlock
	{
		private readonly IBlock _parent;
		private readonly By _by;

		public BlockEnumerable(IBlock parent, By @by)
		{
			_parent = parent;
			_by = @by;
		}

		public IEnumerator<T> GetEnumerator()
		{
			var elements = new WebElementEnumerable(_parent, _by);

			return elements
				.Select((x, i) => (T) Activator.CreateInstance(typeof (T), _parent, new NthItemSpecification(elements, i)))
				.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
