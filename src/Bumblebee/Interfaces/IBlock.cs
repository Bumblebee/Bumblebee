using System.Collections.Generic;

using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
	public interface IBlock : IDraggable, IMonkeyable, IHasParent, IHasSession
	{
		IWebElement FindElement(By @by);
		IEnumerable<IWebElement> FindElements(By @by);
	}
}
