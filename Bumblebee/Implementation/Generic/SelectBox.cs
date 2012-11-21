using System.Collections.Generic;
using System.Linq;
using Bumblebee.Interfaces.Generic;
using OpenQA.Selenium;

namespace Bumblebee.Implementation.Generic
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
