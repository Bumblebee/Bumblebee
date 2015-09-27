using System;

using Bumblebee.Implementation;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class PageWithJQuery : WebBlock
	{
		public PageWithJQuery(Session session) : base(session, TimeSpan.FromSeconds(5))
		{
		}
	}
}
