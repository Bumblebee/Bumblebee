using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class Clickable : Element, IClickable
    {
        public Clickable(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public Clickable(IBlock parent, IWebElement element)
            : base(parent, element)
        {
        }

        public TResult Click<TResult>() where TResult : IBlock
        {
            Tag.Click();
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }
    }

    public class Clickable<TResult> : Clickable, IClickable<TResult> where TResult : Block
    {
        public Clickable(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public Clickable(IBlock parent, IWebElement element)
            : base(parent, element)
        {
        }

        public TResult Click()
        {
            return Click<TResult>();
        }
    }
}
