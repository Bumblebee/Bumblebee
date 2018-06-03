using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
	/// <summary>
	/// Provides an abstraction for page components that represent actual HTML elements.
	/// </summary>
	public interface IHasBackingElement
	{
		/// <summary>
		/// Gets the Selenium IWebElement that underpins this component.
		/// </summary>
		IWebElement Tag { get; }

		/// <summary>
		/// Gets the value of the specified attribute for this component.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <returns>The value of the attribute.</returns>
		string GetAttribute(string name);
	}
}
