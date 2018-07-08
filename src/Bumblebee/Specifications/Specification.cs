using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using OpenQA.Selenium;

namespace Bumblebee.Specifications
{
	internal class Specification : ISpecification
	{
		public By Attribute(string attributeToFind, string attributeValueToFind)
		{
			return By.CssSelector($@"[{attributeToFind}='{attributeValueToFind}']");
		}

		public By Attribute(string attributeToFind, string attributeValueToFind, TimeSpan timeout)
		{
			return Attribute(attributeToFind, attributeValueToFind).WaitingUntil(timeout);
		}

		public By Id(string idToFind)
		{
			return By.Id(idToFind);
		}

		public By Id(string idToFind, TimeSpan timeout)
		{
			return Id(idToFind).WaitingUntil(timeout);
		}

		public By ClassName(string classNameToFind)
		{
			return By.ClassName(classNameToFind);
		}

		public By ClassName(string classNameToFind, TimeSpan timeout)
		{
			return By.ClassName(classNameToFind).WaitingUntil(timeout);
		}

		public By CssSelector(string cssSelectorToFind)
		{
			return By.CssSelector(cssSelectorToFind);
		}

		public By CssSelector(string cssSelectorToFind, TimeSpan timeout)
		{
			return By.CssSelector(cssSelectorToFind).WaitingUntil(timeout);
		}

		public By Function(Expression<Func<ISearchContext, IWebElement>> findElementMethod)
		{
			return new ByFunctionWithSingleOutput(findElementMethod);
		}

		public By Function(Expression<Func<ISearchContext, IWebElement>> findElementMethod, TimeSpan timeout)
		{
			return Function(findElementMethod).WaitingUntil(timeout);
		}

		public By Function(Expression<Func<ISearchContext, IEnumerable<IWebElement>>> findElementsMethod)
		{
			return new ByFunctionWithListOutput(findElementsMethod);
		}

		public By Function(Expression<Func<ISearchContext, IEnumerable<IWebElement>>> findElementsMethod, TimeSpan timeout)
		{
			return Function(findElementsMethod).WaitingUntil(timeout);
		}

		public By LinkText(string linkTextToFind)
		{
			return By.LinkText(linkTextToFind);
		}

		public By LinkText(string linkTextToFind, TimeSpan timeout)
		{
			return By.LinkText(linkTextToFind).WaitingUntil(timeout);
		}

		public By Name(string nameToFind)
		{
			return By.Name(nameToFind);
		}

		public By Name(string nameToFind, TimeSpan timeout)
		{
			return By.Name(nameToFind).WaitingUntil(timeout);
		}

		public By Ordinal(By @by, int ordinal)
		{
			return new ByOrdinal(@by, ordinal);
		}

		public By Ordinal(By @by, int ordinal, TimeSpan timeout)
		{
			return new ByOrdinal(@by, ordinal).WaitingUntil(timeout);
		}

		public By PartialLinkText(string partialLinkTextToFind)
		{
			return By.PartialLinkText(partialLinkTextToFind);
		}

		public By PartialLinkText(string partialLinkTextToFind, TimeSpan timeout)
		{
			return By.PartialLinkText(partialLinkTextToFind).WaitingUntil(timeout);
		}

		public By TagName(string tagNameToFind)
		{
			return By.TagName(tagNameToFind);
		}

		public By TagName(string tagNameToFind, TimeSpan timeout)
		{
			return By.TagName(tagNameToFind).WaitingUntil(timeout);
		}

		public By XPath(string xPathToFind)
		{
			return By.XPath(xPathToFind);
		}

		public By XPath(string xPathToFind, TimeSpan timeout)
		{
			return By.XPath(xPathToFind).WaitingUntil(timeout);
		}
	}
}
