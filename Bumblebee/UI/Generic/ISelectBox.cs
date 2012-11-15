namespace Bumblebee.UI.Generic
{
    public interface ISelectBox<out TResult> : IUIElement where TResult : Block
    {
        TResult Select(int index);
        TResult Select(string text);
    }
}