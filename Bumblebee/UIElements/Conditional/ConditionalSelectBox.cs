using System.Collections.Generic;
using System.Linq;
using Bumblebee.UI.Conditional;
using OpenQA.Selenium;

namespace Bumblebee.UIElements.Conditional
{
    public class ConditionalSelectBox : Element, IConditionalSelectBox
    {
        public ConditionalSelectBox(Block parent, By by) : base(parent, by)
        {
        }

        public ConditionalSelectBox(Block parent, IWebElement element) : base(parent, element)
        {
        }

        private IList<IWebElement> Options
        {
            get { return GetElements(By.TagName("option")); }
        }

        public TResult Select<TResult>(int index) where TResult : Block
        {
            Options[index].Click();
            return Result<TResult>();
        }

        public TResult Select<TResult>(string text) where TResult : Block
        {
            Options.First(opt => opt.Text == text).Click();
            return Result<TResult>();
        }
    }
}
