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

    public class KendoDropDownList<T> : KendoDropDownList, ISelectBox<T>
        where T : IBlock
    {
        public KendoDropDownList(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public KendoDropDownList(IBlock parent, IWebElement tag)
            : base(parent, tag)
        {
        }

        IEnumerable<IOption<T>> ISelectBox<T>.Options
        {
            get { return GetOptions().Select(x => new KendoDropDownListOption<T>(this, x)); }
        }
    }
}
