using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class ConditionalOption : Element, IOption
    {
        public ConditionalOption(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public ConditionalOption(IBlock parent, IWebElement element)
            : base(parent, element)
        {
        }

        public TResult Click<TResult>() where TResult : IBlock
        {
            ParentBlock.Tag.Click();
            Tag.Click();
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }
    }

    public class Option<TResult> : Clickable<TResult>, IOption<TResult> where TResult : Block
    {
        public Option(IBlock parent, By by) : base(parent, by)
        {
        }

        public Option(IBlock parent, IWebElement element) : base(parent, element)
        {
        }
    }
}
