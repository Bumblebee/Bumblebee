using Bumblebee.Interfaces.Generic;
using OpenQA.Selenium;

namespace Bumblebee.Implementation.Generic
{
    public class AriaOption<TResult> : Clickable<TResult>, IOption<TResult> where TResult : Block
    {
        public AriaOption(Block parent, By by) : base(parent, by)
        {
        }

        public AriaOption(Block parent, IWebElement element) : base(parent, element)
        {
        }
        
        public override bool Selected { get { return Dom.GetAttribute("aria-selected") != "true"; } }
    }
}
