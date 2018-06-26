using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class SlowWebPageWithExplicitWait : SlowWebPage
	{
		public SlowWebPageWithExplicitWait(Session session) : base(session, TimeSpan.FromSeconds(10))
		{
		}
	}

	public class SlowWebPageWithNoWait : SlowWebPage
	{
		public SlowWebPageWithNoWait(Session session) : base(session)
		{
		}
	}

	public abstract class SlowWebPage : Page
	{
		protected SlowWebPage(Session session, TimeSpan? timeout = null) : base(session, timeout ?? TimeSpan.FromSeconds(0))
		{
		}

		public ITextField FirstName
		{
			get { return new TextField(this, By.Id("firstName", Wait.Timeout)); }
		}

		public ICheckbox Checkbox
		{
			get { return new Checkbox(this, By.Id("checkedCheckbox", Wait.Timeout)); }
		}

		public ITextField ByAttributeWithWait
		{
			get { return new TextField(this, By.Attribute("x-test", "match", Wait.Timeout)); }
		}

		public ITextField ByAttributeWithNoWait
		{
			get { return new TextField(this, By.Attribute("x-test", "match")); }
		}

		public ITextField ByIdWithWait
		{
			get { return new TextField(this, By.Id("firstName", Wait.Timeout)); }
		}

		public ITextField ByIdWithNoWait
		{
			get { return new TextField(this, By.Id("firstName")); }
		}

		public ITextField ByClassNameWithWait
		{
			get { return new TextField(this, By.ClassName("test", Wait.Timeout)); }
		}

		public ITextField ByClassNameWithNoWait
		{
			get { return new TextField(this, By.ClassName("test")); }
		}

		public ITextField ByCssSelectorWithWait
		{
			get { return new TextField(this, By.CssSelector(".test", Wait.Timeout)); }
		}

		public ITextField ByCssSelectorWithNoWait
		{
			get { return new TextField(this, By.CssSelector(".test")); }
		}

		public ITextField ByFunctionWithSingleOutputSelectorWithWait
		{
			get { return new TextField(this, By.Function(ctx => ctx.FindElement(By.Id("firstName")), Wait.Timeout)); }
		}

		public ITextField ByFunctionWithSingleOutputSelectorWithNoWait
		{
			get { return new TextField(this, By.Function(ctx => ctx.FindElement(By.Id("firstName")))); }
		}

		public ITextField ByFunctionWithListOutputSelectorWithWait
		{
			get { return new TextField(this, By.Function(ctx => ctx.FindElements(By.TagName("input")), Wait.Timeout)); }
		}

		public ITextField ByFunctionWithListOutputSelectorWithNoWait
		{
			get { return new TextField(this, By.Function(ctx => ctx.FindElements(By.TagName("input")))); }
		}

		public IClickable<SlowWebPageWithExplicitWait> ByLinkTextWithWait
		{
			get { return new Clickable<SlowWebPageWithExplicitWait>(this, By.LinkText("Todd", Wait.Timeout)); }
		}

		public IClickable<SlowWebPageWithExplicitWait> ByLinkTextWithNoWait
		{
			get { return new Clickable<SlowWebPageWithExplicitWait>(this, By.LinkText("Todd")); }
		}

		public ITextField ByNameWithWait
		{
			get { return new TextField(this, By.Name("test-name", Wait.Timeout)); }
		}

		public ITextField ByNameWithNoWait
		{
			get { return new TextField(this, By.Name("test-name")); }
		}

		public IClickable<SlowWebPageWithExplicitWait> ByPartialLinkTextWithWait
		{
			get { return new Clickable<SlowWebPageWithExplicitWait>(this, By.PartialLinkText("Todd", Wait.Timeout)); }
		}

		public IClickable<SlowWebPageWithExplicitWait> ByPartialLinkTextWithNoWait
		{
			get { return new Clickable<SlowWebPageWithExplicitWait>(this, By.PartialLinkText("Todd")); }
		}

		public IClickable<SlowWebPageWithExplicitWait> ByTagNameWithWait
		{
			get { return new Clickable<SlowWebPageWithExplicitWait>(this, By.TagName("a", Wait.Timeout)); }
		}

		public IClickable<SlowWebPageWithExplicitWait> ByTagNameWithNoWait
		{
			get { return new Clickable<SlowWebPageWithExplicitWait>(this, By.TagName("a")); }
		}

		public ITextField ByXPathWithWait
		{
			get { return new TextField(this, By.XPath("//*[@id='firstName']", Wait.Timeout)); }
		}

		public ITextField ByXPathWithNoWait
		{
			get { return new TextField(this, By.XPath("//*[@id='firstName']")); }
		}

		public ITextField ByOrdinalWithWait
		{
			get { return new TextField(this, By.Ordinal(By.Id("firstName"), 0, Wait.Timeout)); }
		}

		public ITextField ByOrdinalWithNoWait
		{
			get { return new TextField(this, By.Ordinal(By.Id("firstName"), 0)); }
		}
	}
}
