using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class Option : Clickable, IOption
    {
        public Option(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public Option(IBlock parent, IWebElement element)
            : base(parent, element)
        {
        }

        public override TResult Click<TResult>()
        {
            ParentBlock.Tag.Click();
            return base.Click<TResult>();
        }

        public override TResult DoubleClick<TResult>()
        {
            ParentBlock.Tag.Click();
            return base.DoubleClick<TResult>();
        }
    }

    public class Option<TResult> : Clickable<TResult>, IOption<TResult> where TResult : IBlock
    {
        public Option(IBlock parent, By by) : base(parent, by)
        {
        }

        public Option(IBlock parent, IWebElement element) : base(parent, element)
        {
        }
    }
}
