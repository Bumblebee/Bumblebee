using System;

using Bumblebee.Specifications;

using OpenQA.Selenium;

// ReSharper disable CheckNamespace

namespace Bumblebee
{
	public static class SpecificationExtensions
	{
		public static By Attribute(ISpecification specification, string attributeToFind, string attributeValueToFind)
		{
			return By.CssSelector(String.Format(@"[{0}='{1}']", attributeToFind, attributeValueToFind));
		}

		public static By Id(this ISpecification specification, string idToFind)
		{
			return By.Id(idToFind);
		}

		public static By ClassName(this ISpecification specification, string classNameToFind)
		{
			return By.ClassName(classNameToFind);
		}

		public static By CssSelector(this ISpecification specification, string cssSelectorToFind)
		{
			return By.CssSelector(cssSelectorToFind);
		}

		public static By LinkText(this ISpecification specification, string linkTextToFind)
		{
			return By.LinkText(linkTextToFind);
		}

		public static By Name(this ISpecification specification, string nameToFind)
		{
			return By.Name(nameToFind);
		}

		public static By Ordinal(this ISpecification specification, By @by, int ordinal)
		{
			return new ByOrdinal(@by, ordinal);
		}

		public static By PartialLinkText(this ISpecification specification, string partialLinkTextToFind)
		{
			return By.PartialLinkText(partialLinkTextToFind);
		}

		public static By TagName(this ISpecification specification, string tagNameToFind)
		{
			return By.TagName(tagNameToFind);
		}

		public static By XPath(this ISpecification specification, string xPathToFind)
		{
			return By.XPath(xPathToFind);
		}
	}
}
