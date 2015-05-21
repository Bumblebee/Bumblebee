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
			SwitchToThisFrame();

			return Session.Driver.FindElement(@by);
		}

		public override IEnumerable<IWebElement> FindElements(By @by)
		{
			SwitchToThisFrame();

			return Session.Driver.FindElements(@by);
		}

		private void SwitchToThisFrame()
		{
			Session.Driver.SwitchTo().Frame(Tag);
		}
	}
}
