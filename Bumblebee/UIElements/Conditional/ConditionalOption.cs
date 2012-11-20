using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.UI.Conditional;
using OpenQA.Selenium;

namespace Bumblebee.UIElements.Conditional
{
    public class ConditionalOption : Element, IConditionalOption
    {
        public ConditionalOption(Block parent, By by) : base(parent, by)
        {
        }

        public ConditionalOption(Block parent, IWebElement element) : base(parent, element)
        {
        }

        public TResult Click<TResult>() where TResult : Block
        {
            Dom.Click();
            return Result<TResult>();
        }

        public bool Selected
        {
            get { return Dom.Selected; }
        }
    }
}
