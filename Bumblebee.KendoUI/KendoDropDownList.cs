using System;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.KendoUI
{
	public class KendoDropDownList : Element, ISelectBox
	{
		public KendoDropDownList(IBlock parent, By by) : base(parent, by)
		{
		}

		public KendoDropDownList(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		protected IEnumerable<IWebElement> GetOptions()
		{
			// Kendo generates a new <div> everytime the data source of the drop down is refreshed. Therefore, we have to get the last one that exists.
			var parentList = Session.Driver.FindElements(By.CssSelector(String.Format("[id='{0}-list']", Tag.GetAttribute("id")))).Last();
			return parentList.FindElements(By.TagName("li"));
		}

		public virtual IEnumerable<IOption> Options
		{
			get { return GetOptions().Select(x => new KendoDropDownListOption(this, x)); }
		}
	}

	public class KendoDropDownList<TResult> : KendoDropDownList, ISelectBox<TResult>
		where TResult : IBlock
	{
		public KendoDropDownList(IBlock parent, By by)
			: base(parent, by)
		{
		}

		public KendoDropDownList(IBlock parent, IWebElement tag)
			: base(parent, tag)
		{
		}

		IEnumerable<IOption<TResult>> ISelectBox<TResult>.Options
		{
			get { return GetOptions().Select(x => new KendoDropDownListOption<TResult>(this, x)); }
		}
	}
}
