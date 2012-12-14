using Bumblebee.Interfaces.Generic;
using OpenQA.Selenium;

namespace Bumblebee.Implementation.Generic
{
    public class Option<TResult> : Clickable<TResult>, IOption<TResult> where TResult : Block
    {
        public Option(Block parent, By by) : base(parent, by)
        {
        }

        public Option(Block parent, IWebElement element) : base(parent, element)
        {
        }
    }
}
