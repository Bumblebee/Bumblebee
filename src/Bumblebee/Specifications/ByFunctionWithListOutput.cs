using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

using OpenQA.Selenium;

namespace Bumblebee.Specifications
{
	public class ByFunctionWithListOutput : By
	{
		private readonly Func<ISearchContext, ReadOnlyCollection<IWebElement>> _function;

		public ByFunctionWithListOutput(Expression<Func<ISearchContext, ReadOnlyCollection<IWebElement>>> expression)
		{
			_function = expression.Compile();
			Description = String.Format("By.Function: {0}", expression.Body);
		}

		public override IWebElement FindElement(ISearchContext context)
		{
			var element = _function(context).FirstOrDefault();

			if (element == null)
			{
				throw new NoSuchElementException();
			}

			return element;
		}

		public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
		{
			return _function(context);
		}
	}
}