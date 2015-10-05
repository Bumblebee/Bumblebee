using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;
using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Blocks<TBlock> : IEnumerable<TBlock>
		where TBlock : IBlock
	{
		private readonly IBlock _parent;
		private readonly By _by;

		public Blocks(IBlock parent, By @by)
		{
			_parent = parent;
			_by = @by;
		}

		public IEnumerator<TBlock> GetEnumerator()
		{
			return _parent
				.FindElements(_by)
				.Select((element, index) => Block.Create<TBlock>(_parent, new ByOrdinal(_by, index)))
				.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
