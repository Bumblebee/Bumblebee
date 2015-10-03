using Bumblebee.Implementation;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class ByOrdinalPage : Block
	{
		public ByOrdinalPage(Session session) : base(session, By.TagName("body"))
		{
		}
	}
}
