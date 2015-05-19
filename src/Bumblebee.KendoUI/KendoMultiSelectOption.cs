using System.Diagnostics;

using Bumblebee.Extensions;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.KendoUI
{
	[DebuggerDisplay("KendoMultiSelectOption {ToString()}")]
	public class KendoMultiSelectOption : KendoDropDownListOption
	{
		private readonly IWebElement _tagList;

		public KendoMultiSelectOption(IBlock parent, By by, IWebElement tagList) : base(parent, by)
		{
			_tagList = tagList;
		}

		public KendoMultiSelectOption(IBlock parent, IWebElement element, IWebElement tagList) : base(parent, element)
		{
			_tagList = tagList;
		}

		public override TResult Click<TResult>()
		{
			if (Selected)
			{
				// When an item is selected, a list item is created with a delete button in it.
				var item = _tagList.FindElement(By.XPath("//*[contains(text(), '" + Text + "')]/following-sibling::*"));
				item.Click();

				// Await animation.
				this.Pause(100);
				return Session.CurrentBlock<TResult>(ParentBlock.Tag);
			}

			return base.Click<TResult>();
		}

		public override bool Selected
		{
			get
			{
				// Kendo hides the element in the list and creates a new item in another list.
				var selectedAttribute = Tag.GetAttribute("style");
				return selectedAttribute != null && selectedAttribute == "display: none;";
			}
		}
	}

	[DebuggerDisplay("KendoMultiSelectOption<T> {ToString()}")]
	public class KendoMultiSelectOption<T> : KendoMultiSelectOption, IOption<T>
		where T : IBlock
	{
		public KendoMultiSelectOption(IBlock parent, By by, IWebElement tagList) : base(parent, by, tagList)
		{
		}

		public KendoMultiSelectOption(IBlock parent, IWebElement element, IWebElement tagList) : base(parent, element, tagList)
		{
		}

		public T Click()
		{
			return Click<T>();
		}
	}
}
