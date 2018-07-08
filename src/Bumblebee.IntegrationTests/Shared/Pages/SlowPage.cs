using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class SlowPageWithExplicitWait : SlowPage
	{
		public SlowPageWithExplicitWait(Session session) : base(session, TimeSpan.FromSeconds(10))
		{
		}
	}

	public class SlowPageWithNoWait : SlowPage
	{
		public SlowPageWithNoWait(Session session) : base(session)
		{
		}
	}

	public abstract class SlowPage : Page
	{
		protected SlowPage(Session session, TimeSpan? timeout = null) : base(session, timeout ?? TimeSpan.FromSeconds(0))
		{
		}

		public ITextField FirstName => new TextField(this, By.Id("firstName", Wait.Timeout));

	    public ICheckbox Checkbox => new Checkbox(this, By.Id("checkedCheckbox", Wait.Timeout));

	    public ITextField ByAttributeWithWait => new TextField(this, By.Attribute("x-test", "match", Wait.Timeout));

	    public ITextField ByAttributeWithNoWait => new TextField(this, By.Attribute("x-test", "match"));

	    public ITextField ByIdWithWait => new TextField(this, By.Id("firstName", Wait.Timeout));

	    public ITextField ByIdWithNoWait => new TextField(this, By.Id("firstName"));

	    public ITextField ByClassNameWithWait => new TextField(this, By.ClassName("test", Wait.Timeout));

	    public ITextField ByClassNameWithNoWait => new TextField(this, By.ClassName("test"));

	    public ITextField ByCssSelectorWithWait => new TextField(this, By.CssSelector(".test", Wait.Timeout));

	    public ITextField ByCssSelectorWithNoWait => new TextField(this, By.CssSelector(".test"));

	    public ITextField ByFunctionWithSingleOutputSelectorWithWait => new TextField(this, By.Function(ctx => ctx.FindElement(By.Id("firstName")), Wait.Timeout));

	    public ITextField ByFunctionWithSingleOutputSelectorWithNoWait => new TextField(this, By.Function(ctx => ctx.FindElement(By.Id("firstName"))));

	    public ITextField ByFunctionWithListOutputSelectorWithWait => new TextField(this, By.Function(ctx => ctx.FindElements(By.TagName("input")), Wait.Timeout));

	    public ITextField ByFunctionWithListOutputSelectorWithNoWait => new TextField(this, By.Function(ctx => ctx.FindElements(By.TagName("input"))));

	    public IClickable<SlowPageWithExplicitWait> ByLinkTextWithWait => new Clickable<SlowPageWithExplicitWait>(this, By.LinkText("Todd", Wait.Timeout));

	    public IClickable<SlowPageWithExplicitWait> ByLinkTextWithNoWait => new Clickable<SlowPageWithExplicitWait>(this, By.LinkText("Todd"));

	    public ITextField ByNameWithWait => new TextField(this, By.Name("test-name", Wait.Timeout));

	    public ITextField ByNameWithNoWait => new TextField(this, By.Name("test-name"));

	    public IClickable<SlowPageWithExplicitWait> ByPartialLinkTextWithWait => new Clickable<SlowPageWithExplicitWait>(this, By.PartialLinkText("Todd", Wait.Timeout));

	    public IClickable<SlowPageWithExplicitWait> ByPartialLinkTextWithNoWait => new Clickable<SlowPageWithExplicitWait>(this, By.PartialLinkText("Todd"));

	    public IClickable<SlowPageWithExplicitWait> ByTagNameWithWait => new Clickable<SlowPageWithExplicitWait>(this, By.TagName("a", Wait.Timeout));

	    public IClickable<SlowPageWithExplicitWait> ByTagNameWithNoWait => new Clickable<SlowPageWithExplicitWait>(this, By.TagName("a"));

	    public ITextField ByXPathWithWait => new TextField(this, By.XPath("//*[@id='firstName']", Wait.Timeout));

	    public ITextField ByXPathWithNoWait => new TextField(this, By.XPath("//*[@id='firstName']"));

	    public ITextField ByOrdinalWithWait => new TextField(this, By.Ordinal(By.Id("firstName"), 0, Wait.Timeout));

	    public ITextField ByOrdinalWithNoWait => new TextField(this, By.Ordinal(By.Id("firstName"), 0));
	}
}
