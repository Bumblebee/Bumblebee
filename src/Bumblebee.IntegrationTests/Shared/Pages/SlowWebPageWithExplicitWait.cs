using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class SlowWebPageWithExplicitWait : WebPage
	{
		public SlowWebPageWithExplicitWait(Session session) 
			: base(session, TimeSpan.FromSeconds(10))
		{
		}

		public ITextField FirstName
		{
			get {  return new TextField(this, By.Id("firstName"), Wait.Timeout); }
		}
	}
}
