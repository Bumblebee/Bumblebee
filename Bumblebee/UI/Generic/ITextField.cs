namespace Bumblebee.UI.Generic
{
    public interface ITextField<out TResult> : IUIElement where TResult : Block
    {
        TResult EnterText(string text);
    }
}