using System;

using OpenQA.Selenium;

namespace Bumblebee.Specifications
{
	internal class Specification : ISpecification
	{
		public By Attribute(string attributeToFind, string attributeValueToFind)
		{
			return By.CssSelector(String.Format(@"[{0}='{1}']", attributeToFind, attributeValueToFind));
		}

		public By Id(string idToFind)
		{
			return By.Id(idToFind);
		}

	    public By Id(string idToFind, TimeSpan timeout)
	    {
	        return By.Id(idToFind).WithWaitUntil(timeout);
	    }

	    public By ClassName(string classNameToFind)
		{
			return By.ClassName(classNameToFind);
		}

		public By CssSelector(string cssSelectorToFind)
		{
			return By.CssSelector(cssSelectorToFind);
		}

		public By LinkText(string linkTextToFind)
		{
			return By.LinkText(linkTextToFind);
		}

		public By Name(string nameToFind)
		{
			return By.Name(nameToFind);
		}

		public By Ordinal(By @by, int ordinal)
		{
			return new ByOrdinal(@by, ordinal);
		}

		public By PartialLinkText(string partialLinkTextToFind)
		{
			return By.PartialLinkText(partialLinkTextToFind);
		}

		public By TagName(string tagNameToFind)
		{
			return By.TagName(tagNameToFind);
		}

		public By XPath(string xPathToFind)
		{
			return By.XPath(xPathToFind);
		}
	}
}
