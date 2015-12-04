using System;

using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.JQuery
{
	public static class SpecificationExtensions
	{
		public static By JQuery(this ISpecification specification, string selector)
		{
			return new ByJQuery(selector);
		}

		public static By JQuery(this ISpecification specification, string selector, TimeSpan timeout)
		{
			return specification.JQuery(selector).WaitingUntil(timeout);
		}
	}
}
