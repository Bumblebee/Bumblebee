using Bumblebee.UI.Generic;
using Bumblebee.UIElements.Conditional;
using OpenQA.Selenium;

namespace Bumblebee.UIElements.Generic
{
    public class SelectBox<TResult> : ConditionalSelectBox, ISelectBox<TResult> where TResult : Block
    {
        public SelectBox(Block parent, By by) : base(parent, by)
        {
        }

        public SelectBox(Block parent, IWebElement element) : base(parent, element)
        {
        }

        public TResult Select(int index)
        {
            return Select<TResult>(index);
        }

        public TResult Select(string text)
        {
            return Select<TResult>(text);
        }
    }
}
