using System;
using System.Collections.ObjectModel;
using System.Linq;

using OpenQA.Selenium;

namespace Bumblebee.Specifications
{
	internal class ByOrdinal : By
	{
		private readonly By _by;
		private readonly int _ordinal;

		public ByOrdinal(By @by, int ordinal)
		{
			if (@by == null)
			{
				throw new ArgumentNullException(nameof (@by));
			}

			if (ordinal < 0)
			{
				throw new ArgumentOutOfRangeException(nameof (ordinal));
			}

			_by = @by;
			_ordinal = ordinal;
		}

		public override IWebElement FindElement(ISearchContext context)
		{
			var elements = context.FindElements(_by);

			if (_ordinal >= elements.Count)
			{
				throw new NoSuchElementException();
			}

			return elements
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
			return $"By.Ordinal {_by} #{_ordinal}";
		}
	}
}
