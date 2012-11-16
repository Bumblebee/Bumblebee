namespace Bumblebee.UIElements.Generic
{
    public class JQueryUIOption<TResult> : Clickable<TResult>, IClickable<TResult>, IOption<TResult> where TResult : Block
    {
        public JQueryUIOption(Block parent, By by) : base(parent, by)
        {
        }

        public JQueryUIOption(Block parent, IWebElement element) : base(parent, element)
        {
        }
        
        public bool Selected { get { throw new NotImplementedException(); } }
    }
}
