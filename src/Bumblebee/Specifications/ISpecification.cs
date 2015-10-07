using OpenQA.Selenium;

namespace Bumblebee.Specifications
{
	public interface ISpecification
	{
		By Attribute(string attributeToFind, string attributeValueToFind);
		By Id(string idToFind);
		By ClassName(string classNameToFind);
		By CssSelector(string cssSelectorToFind);
		By LinkText(string linkTextToFind);
		By Name(string nameToFind);
		By Ordinal(By @by, int ordinal);
		By PartialLinkText(string partialLinkTextToFind);
		By TagName(string tagNameToFind);
		By XPath(string xPathToFind);
	}
}
