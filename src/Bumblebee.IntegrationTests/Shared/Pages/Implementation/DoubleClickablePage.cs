using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class DoubleClickablePage : WebBlock
	{
		public DoubleClickablePage(Session session, TimeSpan timeout) : base(session, timeout)
		{
		}

		public DoubleClickablePage(Session session) : base(session)
		{
		}

		public IDoubleClickable<DoubleClickablePage> ParagraphWithStaticPage
		{
			get { return new Clickable<DoubleClickablePage>(this, By.Id("doubleClickable")); }
		}

		public IDoubleClickable ParagraphWithDynamicPage
		{
			get { return new Clickable(this, By.Id("doubleClickable")); }
		}

		public string Result
		{
			get { return FindElement(By.Id("result")).Text; }
		}
	}
}
