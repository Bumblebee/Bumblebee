using Bumblebee.Extensions;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public abstract class SpecificBlock : Block, ISpecificBlock
    {
        public IBlock ParentBlock { get; private set; }

        protected SpecificBlock(IBlock parent, By by) : base(parent.Session)
        {
            SetFinder(()=>parent.Tag.GetElement(by));
        }


        public virtual string Text
        {
            get { return Tag.Text; }
        }

        public virtual bool Selected
        {
            get { return Tag.Selected; }
        }
    }
}
