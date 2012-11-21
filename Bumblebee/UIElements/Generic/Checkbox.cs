using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.UI.Generic;
using OpenQA.Selenium;

namespace Bumblebee.UIElements.Generic
{
    public class Checkbox<TResult> : Element, ICheckbox<TResult> where TResult : Block
    {
        public Checkbox(Block parent, By by) : base(parent, by)
        {
        }

        public Checkbox(Block parent, IWebElement element) : base(parent, element)
        {
        }

        public TResult Check()
        {
            if (!Selected) Dom.Click();
            return Session.CurrentBlock<TResult>();
        }

        public TResult Uncheck()
        {
            if (Selected) Dom.Click();
            return Session.CurrentBlock<TResult>();
        }

        public TResult Toggle()
        {
            Dom.Click();
            return Session.CurrentBlock<TResult>();
        }
    }
}
