using System;

using Bumblebee.Implementation;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class PageWithJQuery : WebPage
	{
		public PageWithJQuery(Session session) : base(session, TimeSpan.FromSeconds(5))
		{
		}
	}
}
