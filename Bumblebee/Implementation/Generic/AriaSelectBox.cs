using System.Collections.Generic;
using System.Linq;
using Bumblebee.Interfaces.Generic;
using OpenQA.Selenium;

namespace Bumblebee.Implementation.Generic
{
    public class AriaSelectBox<TResult> : Element, ISelectBox<TResult> where TResult : Block
    {
        public AriaSelectBox(Block parent, By openSelector)
            : base(parent, openSelector)
        {
            Dom.Click();
        }

        public IEnumerable<IOption<TResult>> Options
        {
            get { return Session.Driver.FindElements(By.CssSelector(".ui-selectmenu-open a")).Select(opt => new AriaOption<TResult>(this, opt)); }
        }
    }
}
