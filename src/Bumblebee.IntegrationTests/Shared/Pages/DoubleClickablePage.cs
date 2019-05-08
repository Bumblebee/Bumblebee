using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class DoubleClickablePage : Page
	{
		public DoubleClickablePage(Session session, TimeSpan timeout) : base(session, timeout)
		{
		}

		public DoubleClickablePage(Session session) : base(session)
		{
		}

		public IDoubleClickable<DoubleClickablePage> ParagraphWithStaticPage => new Clickable<DoubleClickablePage>(this, By.Id("doubleClickable"));

		public IDoubleClickable ParagraphWithDynamicPage => new Clickable(this, By.Id("doubleClickable"));

		public string Result => FindElement(By.Id("result")).Text;
	}
}
