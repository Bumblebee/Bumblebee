using System;
using System.Collections.ObjectModel;
using System.Linq;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	internal class ByOrdinal : By
	{
		private readonly By _by;
		private readonly int _ordinal;

		public ByOrdinal(By @by, int ordinal)
		{
			_by = @by;
			_ordinal = ordinal;
		}

		public override IWebElement FindElement(ISearchContext context)
		{
			return context.FindElements(_by)
				.ElementAt(_ordinal);
		}

		public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
		{
			var list = context.FindElements(_by)
				.Skip(_ordinal)
				.Take(1)
				.ToList();

			return new ReadOnlyCollection<IWebElement>(list);
		}

		public override string ToString()
		{
			return String.Format("By.Ordinal {0} #{1}", _by, _ordinal);
		}
	}
}
