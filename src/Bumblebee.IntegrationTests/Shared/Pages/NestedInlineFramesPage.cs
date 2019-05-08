using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class NestedInlineFramesPage : Page
	{
		public NestedInlineFramesPage(Session session) : base(session, TimeSpan.FromSeconds(5))
		{
		}

		public string Text
		{
			get { return FindElement(By.Id("GrandparentSpan")).Text; }
		}

		public NestedChildFrame ChildFrame
		{
			get { return new NestedChildFrame(this, By.Id("NestedInlineFrameChild")); }
		}
	}

	public class NestedChildFrame : InlineFrame
	{
		public NestedChildFrame(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public string Text
		{
			get { return FindElement(By.Id("ParentSpan")).Text; }
		}

		public NestedGrandchildFrame ChildFrame
		{
			get { return new NestedGrandchildFrame(this, By.Id("NestedInlineFrameGrandchild")); }
		}
	}

	public class NestedGrandchildFrame : InlineFrame
	{
		public NestedGrandchildFrame(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public IClickable<NestedChildFrame> ParentLink
		{
			get { return new Clickable<NestedChildFrame>(this, By.Id("ParentLink")); }
		}

		public IClickable<NestedInlineFramesPage> GrandparentLink
		{
			get { return new Clickable<NestedInlineFramesPage>(this, By.Id("GrandparentLink")); }
		}
	}
}
