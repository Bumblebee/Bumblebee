using System.Collections.Generic;
using System.Linq;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	internal class ByOrdinal : By
	{
		private readonly IEnumerable<IWebElement> _source;
		private readonly int _ordinal;

		public ByOrdinal(IEnumerable<IWebElement> source, int ordinal)
		{
			_source = source;
			_ordinal = ordinal;
		}

		public override IWebElement FindElement(ISearchContext context)
		{
			return _source.ElementAt(_ordinal);
		}
	}
}
