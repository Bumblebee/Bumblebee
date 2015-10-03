using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class SlowWebPageWithNoWait : WebPage
	{
		public SlowWebPageWithNoWait(Session session) 
			: base(session, TimeSpan.FromSeconds(0))
		{
		}

		public ITextField FirstName
		{
			get {  return Wait.Until(x => new TextField(this, By.Id("firstName")));}
		}
		
	}
}