using System.Collections.Generic;
using System.Linq;
using Bumblebee.Interfaces;
using Bumblebee.Interfaces.Conditional;
using OpenQA.Selenium;

namespace Bumblebee.Implementation.Conditional
{
    public class ConditionalSelectBox : Element, IConditionalSelectBox
    {
        public ConditionalSelectBox(IBlock parent, By by) : base(parent, by)
        {
        }

        public ConditionalSelectBox(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public IEnumerable<IConditionalOption> Options
        {
            get { return GetElements(By.TagName("option")).Select(opt => new ConditionalOption(this, opt)); }
        }
    }
}
