using OpenQA.Selenium;

namespace Bumblebee
{
    public abstract class Element : SpecificBlock
    {
        protected IWebElement ParentElement { get; private set; }

        protected Element(Block parent, By by) : base(parent.Session, parent.Tag.GetElement(by))
        {
            ParentElement = parent.Tag;
        }

        protected Element(Block parent, IWebElement tag) : base(parent.Session, tag)
        {
            ParentElement = parent.Tag;
        }

        public string Text
        {
            get { return Tag.Text; }
        }

        public virtual bool Selected
        {
            get { return Tag.Selected; }
        }
    }
}
