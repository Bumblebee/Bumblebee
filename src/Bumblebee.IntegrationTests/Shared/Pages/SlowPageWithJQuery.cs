using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.JQuery;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class SlowPageWithJQuery : Page
	{
		public SlowPageWithJQuery(Session session) : base(session)
		{
		}

		public IClickable<SlowPageWithJQuery> TheLinkWithNoTimeout
		{
			get { return new Clickable<SlowPageWithJQuery>(this, By.JQuery("#ElementContainer .the-link")); }
		}

		public IClickable<SlowPageWithJQuery> TheLinkWithTimeout
		{
			get { return new Clickable<SlowPageWithJQuery>(this, By.JQuery("#ElementContainer .the-link", TimeSpan.FromSeconds(10))); }
		}
	}
}
