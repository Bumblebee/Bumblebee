using System;
using System.Collections.Generic;
using System.Linq;

using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Bumblebee.Extensions
{
	public static class WebElementConvenience
	{
		[Obsolete("This method is obsolete. It will be removed in a future version. Please use the FindElements() instead.")]
		public static IList<IWebElement> GetElements(this ISearchContext driver, By by)
		{
			return driver.FindElements(by);
		}

		[Obsolete("This method is obsolete. It will be removed in a future version. Please use the FindElement() instead.")]
		public static IWebElement GetElement(this ISearchContext driver, By by)
		{
			return driver.FindElement(by);
		}

		public static IWebDriver GetDriver(this IWebElement element)
		{
			return ((IWrapsDriver) element).WrappedDriver;
		}

		public static string GetID(this IWebElement element)
		{
			return element.GetAttribute("id");
		}

		public static IEnumerable<string> GetClasses(this IWebElement element)
		{
			return element.GetAttribute("class").Split(' ');
		}

		public static bool HasClass(this IWebElement element, string className)
		{
			return element.GetClasses().Any(@class => @class.Equals(className));
		}

		public static void SetAttribute(this IWebElement element, string attribute, string value)
		{
			element.GetDriver().ExecuteScript<object>("arguments[0].setAttribute(arguments[1], arguments[2])", element, attribute, value);
		}
	}
}
