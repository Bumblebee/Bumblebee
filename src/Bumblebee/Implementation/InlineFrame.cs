using System.Collections.Generic;

using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public abstract class InlineFrame : Block
	{
		protected InlineFrame(Session session, By @by) : base(session, @by)
		{
			SwitchToThisFrame();
		}

		protected InlineFrame(IBlock parent, By @by) : base(parent, @by)
		{
			SwitchToThisFrame();
		}

		public override IWebElement FindElement(By @by)
		{
			return SwitchToThisFrame().FindElement(@by);
		}

		public override IEnumerable<IWebElement> FindElements(By @by)
		{
			return SwitchToThisFrame().FindElements(@by);
		}

		private IWebDriver SwitchToThisFrame()
		{
			return Session.Driver.SwitchTo().Frame(Tag);
		}
	}
}
