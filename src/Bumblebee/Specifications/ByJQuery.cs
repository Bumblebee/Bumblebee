using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.Extensions;

namespace Bumblebee.Specifications
{
	internal class ByJQuery : By
	{
		private static readonly Type WebDriverType = typeof (IWebDriver);
		private static readonly Type WebElementType = typeof (IWebElement);

		private readonly string _selector;

		public ByJQuery(string selector)
		{
			if (String.IsNullOrWhiteSpace(selector))
			{
				throw new ArgumentNullException("selector");
			}

			_selector = selector;
		}

		public override IWebElement FindElement(ISearchContext context)
		{
			var elements = FindElements(context);

			if (elements.Any() == false)
			{
				throw new NoSuchElementException(String.Format("Unable to find element matching selector: '{0}'", _selector));
			}

			return elements.First();
		}

		public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
		{
			var result = Enumerable.Empty<IWebElement>();

			if (WebDriverType.IsInstanceOfType(context))
			{
				result = FindElements((IWebDriver) context);
			}
			else if (WebElementType.IsInstanceOfType(context))
			{
				result = FindElements((IWebElement) context);
			}

			return new ReadOnlyCollection<IWebElement>(result.ToList());
		}

		private IEnumerable<IWebElement> FindElements(IWebDriver driver)
		{
			return driver.ExecuteJavaScript<IEnumerable>("return $(arguments[0]).get();", _selector)
				.Cast<IWebElement>();
		}

		private IEnumerable<IWebElement> FindElements(IWebElement element)
		{
			IEnumerable<IWebElement> result = Enumerable.Empty<IWebElement>();

			var wrapper = element as IWrapsDriver;

			if (wrapper != null)
			{
				var driver = wrapper.WrappedDriver;

				result = driver.ExecuteJavaScript<IEnumerable>("return $(arguments[0]).find(arguments[1]).get();", element, _selector)
					.Cast<IWebElement>();
			}

			return result;
		}

		public override string ToString()
		{
			return String.Format("By.JQuery {0}", _selector);
		}
	}
}
