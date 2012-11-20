using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.UI.Generic;
using OpenQA.Selenium;

namespace Bumblebee.UIElements.Generic
{
    public class JQueryUISelectBox<TResult> : Element, ISelectBox<TResult> where TResult : Block
    {
        public JQueryUISelectBox(Block parent, By optionsSelector, By openSelector)
            : base(parent, optionsSelector)
        {
            Session.Driver.FindElement(openSelector).Click();
        }

        public IEnumerable<IOption<TResult>> Options
        {
            get { return GetElements(By.TagName("a")).Select(opt => new Option<TResult>(this, opt)); }
        }
    }
}
