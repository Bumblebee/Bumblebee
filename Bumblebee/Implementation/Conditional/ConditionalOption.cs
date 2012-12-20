using Bumblebee.Interfaces;
using Bumblebee.Interfaces.Conditional;
using OpenQA.Selenium;

namespace Bumblebee.Implementation.Conditional
{
    public class ConditionalOption : Element, IConditionalOption
    {
        public ConditionalOption(IBlock parent, By by) : base(parent, by)
        {
        }

        public ConditionalOption(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public TResult Click<TResult>() where TResult : IBlock
        {
            ParentBlock.Tag.Click();
            Tag.Click();
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }
    }
}
