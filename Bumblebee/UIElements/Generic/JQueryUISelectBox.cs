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
        public JQueryUISelectBox(Block parent, By openSelector)
            : base(parent, openSelector)
        {
            Dom.Click();
        }

        public IEnumerable<IOption<TResult>> Options
        {
            get { return Session.Driver.FindElements(By.CssSelector(".ui-selectmenu-open a")).Select(opt => new JQueryUIOption<TResult>(this, opt)); }
        }
    }
}
