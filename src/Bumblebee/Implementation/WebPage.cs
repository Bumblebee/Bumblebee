using System;

using Bumblebee.Extensions;
using Bumblebee.Setup;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Implementation
{
	public abstract class WebPage : Page
	{
		protected WebDriverWait Wait { get; private set; }

		protected WebPage(Session session, TimeSpan timeout) 
			: base(session)
		{
			this.Pause(200);
			Wait = new WebDriverWait(Session.Driver, timeout);
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