using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Bumblebee
{
    public abstract class Element : Block
    {
        protected Element(Block parent, By by) : base(parent.Session)
        {
            Dom = parent.GetElement(by);
        }

        protected Element(Block parent, IWebElement element) : base(parent.Session)
        {
            Dom = element;
        }

        public string Text
        {
            get { return Dom.Text; }
        }
    }
}
