using System;
using System.Collections.Generic;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Bumblebee.Extensions
{
	public static class JavaScriptExecution
	{
		public static T ExecuteScript<T>(this IWebDriver driver, string script, params object[] args)
		{
			return driver.ExecuteJavaScript<T>(script, args);
		}

		public static IEnumerable<IWebElement> GetElementsByJQuery(this IWebDriver driver, string query)
		{
			return driver.ExecuteScript<IEnumerable<IWebElement>>(String.Format("return $('{0}').get();", query));
		}

		public static T ExecuteFunction<T>(this IWebElement element, string function, params object[] args)
		{
			return element.GetDriver().ExecuteScript<T>("arguments[0]." + function, element, args);
		}

		public static T ExecuteJQueryFunction<T>(this IWebElement element, string function, params object[] args)
		{
			return element.GetDriver().ExecuteScript<T>("$(arguments[0])." + function, element, args);
		}
	}
}
