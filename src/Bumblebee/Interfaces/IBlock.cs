using System.Collections.Generic;

using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
	public interface IBlock : IDraggable, IMonkeyable, IHasParent
	{
		Session Session { get; }
		IWebElement FindElement(By @by);
		IEnumerable<IWebElement> FindElements(By @by);
	}
}
