using Bumblebee.UI.Conditional;
using OpenQA.Selenium;

namespace Bumblebee.UIElements.Conditional
{
    public class ConditionalClickable : Element, IConditionalClickable
    {
        public ConditionalClickable(Block parent, By by)
            : base(parent, by)
        {
        }

        public ConditionalClickable(Block parent, IWebElement element)
            : base(parent, element)
        {
        }

        public TResult Click<TResult>() where TResult : Block
        {
            Dom.Click();
            return Result<TResult>();
        }
    }
}
