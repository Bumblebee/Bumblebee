using System.Collections.Generic;
using System.Linq;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class ConditionalSelectBox : Element, ISelectBox
    {
        public ConditionalSelectBox(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public ConditionalSelectBox(IBlock parent, IWebElement element)
            : base(parent, element)
        {
        }

        public IEnumerable<IOption> Options
        {
            get { return GetElements(By.TagName("option")).Select(opt => new ConditionalOption(this, opt)); }
        }
    }

    public class SelectBox<TResult> : Element, ISelectBox<TResult> where TResult : Block
    {
        public SelectBox(IBlock parent, By by) : base(parent, by)
        {
        }

        public SelectBox(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public IEnumerable<IOption<TResult>> Options
        {
            get { return GetElements(By.TagName("option")).Select(opt => new Option<TResult>(ParentBlock, opt)); }
        }
    }
}
