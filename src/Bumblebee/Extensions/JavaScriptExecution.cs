using System;
using System.Collections.Generic;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Bumblebee.Extensions
{
	public static class JavaScriptExecution
	{
		[Obsolete("Please use the Selenium built-in function OpenQA.Selenium.Support.Extensions.WebDriverExtensions.ExecuteJavaScript, or call the ExecuteJavaScript method directly off of the Session object.")]
		public static T ExecuteScript<T>(this IWebDriver driver, string script, params object[] args)
		{
			return driver.ExecuteJavaScript<T>(script, args);
		}

		public static IEnumerable<IWebElement> GetElementsByJQuery(this IWebDriver driver, string query)
		{
			return driver.ExecuteJavaScript<IEnumerable<IWebElement>>(String.Format("return $('{0}').get();", query));
		}

		public static T ExecuteFunction<T>(this IWebElement element, string function, params object[] args)
		{
			return element.GetDriver().ExecuteJavaScript<T>("arguments[0]." + function, element, args);
		}

		public static T ExecuteJQueryFunction<T>(this IWebElement element, string function, params object[] args)
		{
			return element.GetDriver().ExecuteJavaScript<T>("$(arguments[0])." + function, element, args);
		}
	}
}
