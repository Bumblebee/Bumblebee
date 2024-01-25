using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Bumblebee.Extensions
{
	public static class JavaScriptExecution
	{
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
