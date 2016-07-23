using System;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class PageWithJQuery : WebPage
	{
		public PageWithJQuery(Session session) : base(session, TimeSpan.FromSeconds(5))
		{
		}

		public UnorderedList ListA
		{
			get { return new UnorderedList(this, By.Id("ListA")); }
		}

		public UnorderedList ListB
		{
			get { return new UnorderedList(this, By.Id("ListB")); }
		}
	}

	public class UnorderedList : Block
	{
		public UnorderedList(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public IEnumerable<string> Items
		{
			get { return FindElements(By.TagName("li")).Select(x => x.Text); }
		} 
	}
}
