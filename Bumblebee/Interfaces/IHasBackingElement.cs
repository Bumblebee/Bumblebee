using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
	public interface IHasBackingElement
	{
		IWebElement Tag { get; }
	}
}
