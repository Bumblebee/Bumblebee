using Bumblebee.UI.Generic;
using OpenQA.Selenium;

namespace Bumblebee.UIElements.Generic
{
    public class TextField<TResult> : Element, ITextField<TResult> where TResult : Block
    {
        public TextField(Block parent, By by)
            : base(parent, by)
        {
        }

        public TextField(Block parent, IWebElement element)
            : base(parent, element)
        {
        }

        public TResult EnterText(string text)
        {
            Dom.SendKeys(text);
            return Result<TResult>();
        }
    }
}
