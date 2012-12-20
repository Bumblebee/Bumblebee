using Bumblebee.Implementation.Conditional;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class Clickable<TResult> : ConditionalClickable, IClickable<TResult> where TResult : Block
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
