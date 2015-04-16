using System.Collections.Generic;
using System.Linq;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class NthItemSpecification : By
	{
		private readonly IEnumerable<IWebElement> _source;
		private readonly int _ordinal;

		public NthItemSpecification(IEnumerable<IWebElement> source, int ordinal)
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
