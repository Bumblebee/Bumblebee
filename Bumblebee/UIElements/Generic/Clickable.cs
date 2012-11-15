using Bumblebee.UI.Generic;
using Bumblebee.UIElements.Conditional;
using OpenQA.Selenium;

namespace Bumblebee.UIElements.Generic
{
    public class Clickable<TResult> : ConditionalClickable, IClickable<TResult> where TResult : Block
    {
        public Clickable(Block parent, By by)
            : base(parent, by)
        {
        }

        public Clickable(Block parent, IWebElement element)
            : base(parent, element)
        {
        }

        public TResult Click()
        {
            return Click<TResult>();
        }
    }
}
