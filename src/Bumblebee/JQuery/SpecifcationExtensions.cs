using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.JQuery
{
	public static class SpecifcationExtensions
	{
		public static By JQuery(this ISpecification specification, string selector)
		{
			return new ByJQuery(selector);
		}
	}
}
