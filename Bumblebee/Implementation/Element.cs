using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public abstract class Element : SpecificBlock
    {
        protected IBlock ParentBlock { get; private set; }

        protected Element(IBlock parent, By by) : base(parent.Session, parent.Tag.GetElement(by))
        {
            ParentBlock = parent;
        }

        protected Element(IBlock parent, IWebElement tag) : base(parent.Session, tag)
        {
            ParentBlock = parent;
        }

        public virtual string Text
        {
            get { return Tag.Text; }
        }

        public virtual bool Selected
        {
            get { return Tag.Selected; }
        }

        public TCustomResult Then<TCustomResult>() where TCustomResult : IBlock
        {
            return Session.CurrentBlock<TCustomResult>(ParentBlock.Tag);
        }
    }
}
