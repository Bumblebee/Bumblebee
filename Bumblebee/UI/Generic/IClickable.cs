namespace Bumblebee.UI.Generic
{
    public interface IClickable<out TResult> : IUIElement where TResult : Block
    {
        TResult Click();
        string Text { get; }
    }
}
