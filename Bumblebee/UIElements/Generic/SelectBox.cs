using System.Collections.Generic;
using System.Linq;
using Bumblebee.UI.Generic;
using Bumblebee.UIElements.Conditional;
using OpenQA.Selenium;

namespace Bumblebee.UIElements.Generic
{
    public class SelectBox<TResult> : Element, ISelectBox<TResult> where TResult : Block
    {
        public SelectBox(Block parent, By by) : base(parent, by)
        {
        }

        public SelectBox(Block parent, IWebElement element) : base(parent, element)
        {
        }

        public IEnumerable<IOption<TResult>> Options
        {
            get { return GetElements(By.TagName("option")).Select(opt => new Option<TResult>(this, opt)); }
        }
    }
}
