using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation.Generic
{
    public class Copy<TResult> : Element, ICopy<TResult> where TResult : Block
    {
        public Copy(Block parent, By by) : base(parent, by)
        {
        }

        public Copy(Block parent, IWebElement element) : base(parent, element)
        {
        }

        public TResult VerifyContent(string text)
        {
            this.VerifyText(text);
            return Session.CurrentBlock<TResult>(ParentElement);
        }
    }
}
