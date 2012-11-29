using OpenQA.Selenium;

namespace Bumblebee
{
    public abstract class Element : SpecificBlock
    {
        protected IWebElement ParentElement { get; private set; }

        protected Element(Block parent, By by) : base(parent.Session, parent.GetElement(by))
        {
            ParentElement = parent.Dom;
        }

        protected Element(Block parent, IWebElement dom) : base(parent.Session, dom)
        {
            ParentElement = parent.Dom;
        }

        public string Text
        {
            get { return Dom.Text; }
        }

        public virtual bool Selected
        {
            get { return Dom.Selected; }
        }
    }
}
