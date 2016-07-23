using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	/// <summary>
	/// This represents an &lt;iframe&gt; element.
	/// </summary>
	/// <remarks>
	/// Note that for the <see cref="Tag" /> property, we make the assumption that the page inside the frame has a &lt;body&gt; element.
	/// </remarks>
	public abstract class InlineFrame : Block
	{
		public override IWebElement Tag
		{
			get
			{
				return Session.Driver
					.SwitchTo().Frame(base.Tag)
					.FindElement(By.TagName("body"));
			}
		}

		protected InlineFrame(IBlock parent, By @by) : base(parent, @by)
		{
		}
	}
}
