using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class TextField<TResult> : Element, ITextField<TResult> where TResult : IBlock
    {
        public TextField(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public TextField(IBlock parent, IWebElement element)
            : base(parent, element)
        {
        }

        public TResult EnterText(string text)
        {
            Tag.SendKeys(text);
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }
    }
}
