using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
