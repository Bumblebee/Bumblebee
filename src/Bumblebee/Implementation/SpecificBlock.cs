using System;

using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	[Obsolete("This type is obsolete, because we have shifted to a lazy loading pattern for tags/scoped element.  If this is for a single property on another page/block, then please derive that block from the Block or WebBlock types.  If it is for supporting a list of Blocks of the same type that come from a call to FindElements(By @by), then please use the new FindBlocks<T>() method or new up Blocks<T>().", true)]
	public abstract class SpecificBlock : Page
	{
		protected SpecificBlock(Session session, IWebElement tag)
			: base(session)
		{
		}
	}
}
