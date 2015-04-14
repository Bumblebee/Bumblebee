using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.KendoUI
{
	public class KendoMultiSelect : KendoDropDownList
	{
		public KendoMultiSelect(IBlock parent, By by) : base(parent, by)
		{
		}

		public KendoMultiSelect(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		public override IEnumerable<IOption> Options
		{
			get { return GetOptions().Select(x => new KendoMultiSelectOption(this, x, Tag.FindElement(By.XPath("..")).FindElement(By.CssSelector("div.k-multiselect-wrap > ul")))); }
		}
	}

	public class KendoMultiSelect<TResult> : KendoDropDownList, ISelectBox<TResult>
		where TResult : IBlock
	{
		public KendoMultiSelect(IBlock parent, By by) : base(parent, by)
		{
		}

		public KendoMultiSelect(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		IEnumerable<IOption<TResult>> ISelectBox<TResult>.Options
		{
			get { return GetOptions().Select(x => new KendoMultiSelectOption<TResult>(this, x, Tag.FindElement(By.XPath("..")).FindElement(By.CssSelector("div.k-multiselect-wrap > ul")))); }
		}
	}
}
