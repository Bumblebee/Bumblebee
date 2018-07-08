using System;

using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    [Obsolete("Use Page now since Wait functionality has been added to the base.", error: true)]

    public abstract class WebPage : Page
	{
		protected WebPage(Session session, TimeSpan timeout) 
			: base(session)
		{
		}

		protected WebPage(Session session) 
			: this(session, TimeSpan.FromTicks(3000))
		{
		}

		public override IWebElement Tag
		{
			get { return Wait.Until(driver => base.Tag); }
		}
	}
}