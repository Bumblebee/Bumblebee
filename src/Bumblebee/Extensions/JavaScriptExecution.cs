using System.Collections.Generic;
using OpenQA.Selenium;

namespace Bumblebee.Extensions
{
	public static class JavaScriptExecution
	{
		public static T ExecuteScript<T>(this IWebDriver driver, string script, params object[] args)
		{
			return (T) ((IJavaScriptExecutor) driver).ExecuteScript(script, args);
		}

		public static IEnumerable<IWebElement> GetElementsByJQuery(this IWebDriver driver, string query)
		{
			return driver.ExecuteScript<IEnumerable<IWebElement>>(string.Format("return $('{0}').get();", query));
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
