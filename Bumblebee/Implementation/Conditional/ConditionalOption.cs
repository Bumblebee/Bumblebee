using Bumblebee.Interfaces.Conditional;
using OpenQA.Selenium;

namespace Bumblebee.Implementation.Conditional
{
    public class ConditionalOption : Element, IConditionalOption
    {
        public ConditionalOption(Block parent, By by) : base(parent, by)
        {
        }

        public ConditionalOption(Block parent, IWebElement element) : base(parent, element)
        {
        }

        public TResult Click<TResult>() where TResult : Block
        {
            Dom.Click();
            return Session.CurrentBlock<TResult>(ParentElement);
        }
    }
}
