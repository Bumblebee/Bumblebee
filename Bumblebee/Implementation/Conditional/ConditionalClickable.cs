using Bumblebee.Interfaces;
using Bumblebee.Interfaces.Conditional;
using OpenQA.Selenium;

namespace Bumblebee.Implementation.Conditional
{
    public class ConditionalClickable : Element, IConditionalClickable
    {
        public ConditionalClickable(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public ConditionalClickable(IBlock parent, IWebElement element)
            : base(parent, element)
        {
        }

        public TResult Click<TResult>() where TResult : IBlock
        {
            Tag.Click();
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }
    }
}
