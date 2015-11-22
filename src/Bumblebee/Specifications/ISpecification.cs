using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

using OpenQA.Selenium;

namespace Bumblebee.Specifications
{
	public interface ISpecification
	{
		By Attribute(string attributeToFind, string attributeValueToFind);
		By Attribute(string attributeToFind, string attributeValueToFind, TimeSpan timeout);
		By Id(string idToFind);
		By Id(string idToFind, TimeSpan timeout);
		By ClassName(string classNameToFind);
		By ClassName(string classNameToFind, TimeSpan timeout);
		By CssSelector(string cssSelectorToFind);
		By CssSelector(string cssSelectorToFind, TimeSpan timeout);
		By Function(Expression<Func<ISearchContext, IWebElement>> findElementMethod);
		By Function(Expression<Func<ISearchContext, IWebElement>> findElementMethod, TimeSpan timeout);
		By Function(Expression<Func<ISearchContext, ReadOnlyCollection<IWebElement>>> findElementsMethod);
		By Function(Expression<Func<ISearchContext, ReadOnlyCollection<IWebElement>>> findElementsMethod, TimeSpan timeout);
		By LinkText(string linkTextToFind);
		By LinkText(string linkTextToFind, TimeSpan timeout);
		By Name(string nameToFind);
		By Name(string nameToFind, TimeSpan timeout);
		By Ordinal(By @by, int ordinal);
		By Ordinal(By @by, int ordinal, TimeSpan timeout);
		By PartialLinkText(string partialLinkTextToFind);
		By PartialLinkText(string partialLinkTextToFind, TimeSpan timeout);
		By TagName(string tagNameToFind);
		By TagName(string tagNameToFind, TimeSpan timeout);
		By XPath(string xPathToFind);
		By XPath(string xPathToFind, TimeSpan timeout);
	}
}
