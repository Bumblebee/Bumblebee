using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;
using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Blocks<T> : IEnumerable<T>
		where T : IBlock
	{
		private readonly IBlock _parent;
		private readonly By _by;

		public Blocks(IBlock parent, By @by)
		{
			_parent = parent;
			_by = @by;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _parent
				.FindElements(_by)
				.Select((x, i) => Factory.CreateBlockFromParentAndSpecification<T>(_parent, new ByOrdinal(_by, i)))
				.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
