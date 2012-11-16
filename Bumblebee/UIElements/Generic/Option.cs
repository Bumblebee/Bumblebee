namespace Bumblebee.UIElements.Generic
{
    public class Option<TResult> : Clickable<TResult>, IClickable<TResult>, IOption<TResult> where TResult : Block
    {
        public Option(Block parent, By by) : base(parent, by)
        {
        }

        public Option(Block parent, IWebElement element) : base(parent, element)
        {
        }
        
        public bool Selected { get { return Dom.Selected; } }
    }
}
