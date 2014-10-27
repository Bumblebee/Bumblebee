using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.KendoUI
{
    public class KendoDropDownList : Element, ISelectBox
    {
        public KendoDropDownList(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public KendoDropDownList(IBlock parent, IWebElement tag)
            : base(parent, tag)
        {
        }

        protected IEnumerable<IWebElement> GetOptions()
        {
            var parentList = Session.Driver.FindElement(By.Id(Tag.GetAttribute("id") + "-list"));
            return parentList.FindElements(By.TagName("li"));
        }

        public IEnumerable<IOption> Options
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
