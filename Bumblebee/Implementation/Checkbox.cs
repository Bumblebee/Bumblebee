using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class Checkbox<TResult> : Element, ICheckbox<TResult> where TResult : IBlock
    {
        public Checkbox(IBlock parent, By by) : base(parent, by)
        {
        }

        public Checkbox(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public virtual TResult Check()
        {
            if (!Selected) Tag.Click();
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }

        public virtual TResult Uncheck()
        {
            if (Selected) Tag.Click();
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }

        public virtual TResult Toggle()
        {
            Tag.Click();
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }
    }
}
