using Bumblebee.Interfaces.Generic;
using OpenQA.Selenium;

namespace Bumblebee.Implementation.Generic
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
            return Session.CurrentBlock<TResult>(ParentElement);
        }

        public TResult Uncheck()
        {
            if (Selected) Dom.Click();
            return Session.CurrentBlock<TResult>(ParentElement);
        }

        public TResult Toggle()
        {
            Dom.Click();
            return Session.CurrentBlock<TResult>(ParentElement);
        }
    }
}
