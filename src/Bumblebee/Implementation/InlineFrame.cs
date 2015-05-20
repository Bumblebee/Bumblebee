using System.Collections.Generic;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public abstract class InlineFrame : Block
	{
		protected InlineFrame(IBlock parent, By @by) : base(parent, @by)
		{
			Session.Driver.SwitchTo().Frame(Tag);
		}

		public override IWebElement FindElement(By @by)
		{
			return Session.Driver.FindElement(@by);
		}

		public override IEnumerable<IWebElement> FindElements(By @by)
		{
			return Session.Driver.FindElements(@by);
		}
	}
}
