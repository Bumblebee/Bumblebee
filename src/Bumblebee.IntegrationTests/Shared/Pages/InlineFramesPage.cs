using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class InlineFramesPage : WebPage
	{
		public InlineFramesPage(Session session) : base(session, TimeSpan.FromSeconds(5))
		{
		}

		public string Text
		{
			get { return FindElement(By.Id("TheSpan")).Text; }
		}

		public ChildFrame Child
		{
			get { return new ChildFrame(this, By.Id("InlineFrame")); }
		}
	}

	public class ChildFrame : InlineFrame
	{
		public const string TheLinkId = "TheLink";

		public ChildFrame(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public IClickable<InlineFramesPage> TheLink
		{
			get { return new Clickable<InlineFramesPage>(this, By.Id(TheLinkId)); }
		}
	}
}
