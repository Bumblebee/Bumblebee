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

        public virtual TResult EnterText(string text)
        {
            Tag.Clear();
            return AppendText(text);
        }

        public virtual TResult AppendText(string text)
        {
            Tag.SendKeys(text);

            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }

        public override string Text
        {
            get { return Tag.GetAttribute("value"); }
        }
    }
}
