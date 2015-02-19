using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class Checkbox : SpecificBlock, ICheckbox
    {
        public Checkbox(IBlock parent, By by) : base(parent, by)
        {
        }

        public TCustomResult Check<TCustomResult>() where TCustomResult : IBlock
        {
            if (!Selected) Tag.Click();
            return Session.CurrentBlock<TCustomResult>(ParentBlock.Tag);
        }

        public TCustomResult Uncheck<TCustomResult>() where TCustomResult : IBlock
        {
            if (Selected) Tag.Click();
            return Session.CurrentBlock<TCustomResult>(ParentBlock.Tag);
        }

        public TCustomResult Toggle<TCustomResult>() where TCustomResult : IBlock
        {
            Tag.Click();
            return Session.CurrentBlock<TCustomResult>(ParentBlock.Tag);
        }
    }

    public class Checkbox<TResult> : Checkbox, ICheckbox<TResult> where TResult : IBlock
    {
        public Checkbox(IBlock parent, By by) : base(parent, by)
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
