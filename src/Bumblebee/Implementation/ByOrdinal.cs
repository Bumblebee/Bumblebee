using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
		{
			var list = new List<IWebElement>(1)
			{
				FindElement(context)
			};

			return new ReadOnlyCollection<IWebElement>(list);
		}

		public override string ToString()
		{
			return String.Format("Element {0}", _ordinal);
		}
	}
}
