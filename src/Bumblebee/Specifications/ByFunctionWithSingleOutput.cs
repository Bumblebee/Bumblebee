using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

using OpenQA.Selenium;

namespace Bumblebee.Specifications
{
	public class ByFunctionWithSingleOutput : By
	{
		private readonly Func<ISearchContext, IWebElement> _function;

		public ByFunctionWithSingleOutput(Expression<Func<ISearchContext, IWebElement>> expression)
		{
			_function = expression.Compile();
			Description = String.Format("By.Function: {0}", expression.Body);

		}

		public override IWebElement FindElement(ISearchContext context)
		{
			var element = _function(context);

			if (element == null)
			{
				throw new NoSuchElementException();
			}

			return element;
		}

		public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
		{
			var element = _function(context);

			if (element == null)
			{
				return new ReadOnlyCollection<IWebElement>(Enumerable.Empty<IWebElement>().ToList());
			}

			return new ReadOnlyCollection<IWebElement>(new List<IWebElement> { element });
		}
	}
}