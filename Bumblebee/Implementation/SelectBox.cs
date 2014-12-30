using System.Collections.Generic;
using System.Linq;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class SelectBox : Element, ISelectBox
    {
        public SelectBox(IBlock parent, By by)
            : base(parent, by)
        {
        }


        public virtual IEnumerable<IOption> Options
        {
            get { return GetElements(By.TagName("option")).Select(opt => new Option(this, opt)); }
        }
    }

    public class SelectBox<TResult> : Element, ISelectBox<TResult> where TResult : IBlock
    {
        public SelectBox(IBlock parent, By by) : base(parent, by)
        {
        }

        public virtual IEnumerable<IOption<TResult>> Options
        {
            get { return GetElements(By.TagName("option")).Select(opt => new Option<TResult>(ParentBlock, opt)); }
        }
    }
}
