using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
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
