using System;
using System.Diagnostics;

using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.KendoUI
{
	[DebuggerDisplay("KendoDropDownListOption {ToString()}")]
	public class KendoDropDownListOption : Element, IOption
	{
		public KendoDropDownListOption(IBlock parent, By by) : base(parent, by)
		{
		}

		public KendoDropDownListOption(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

		public virtual TResult Click<TResult>() where TResult : IBlock
		{
			ParentBlock.Tag.FindElement(By.XPath("..")).Click();

			// Kendo animation may slow down the showing of the element.
			var wait = new DefaultWait<KendoDropDownListOption>(this)
			{
				Timeout = TimeSpan.FromMilliseconds(10000)
			};

			wait.Until(x => x.Tag.Displayed);

			// Internet Explorer has weird behaviour if we don't pause a bit more.
			this.Pause(100);
			Tag.Click();

			// Await animation.
			this.Pause(100);

			return FindRelated<TResult>();
		}

		public override bool Selected
		{
			get
			{
				var selectedAttribute = Tag.GetAttribute("aria-selected");
				return (selectedAttribute != null) && (selectedAttribute == "true");
			}
		}

		public override string Text
		{
			get { return Tag.GetTextFromHiddenElement(Session.Driver); }
		}

		public override string ToString()
		{
			return string.Format("Selected: {0}, Text: {1}", Selected, Text);
		}
	}

	[DebuggerDisplay("KendoDropDownListOption<T> {ToString()}")]
	public class KendoDropDownListOption<T> : KendoDropDownListOption, IOption<T>
		where T : IBlock
	{
		public KendoDropDownListOption(IBlock parent, By by) : base(parent, by)
		{
		}

		public KendoDropDownListOption(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

		public T Click()
		{
			return Click<T>();
		}
	}
}
