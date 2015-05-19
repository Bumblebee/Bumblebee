using OpenQA.Selenium;

namespace Bumblebee.KendoUI
{
	public static class KendoExtensions
	{
		public static string GetTextFromHiddenElement(this IWebElement self, IWebDriver driver)
		{
			return (string) ((IJavaScriptExecutor) driver).ExecuteScript("return arguments[0].innerText || arguments[0].textContent", self);
		}
	}
}
