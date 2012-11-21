namespace Bumblebee.UI.Generic
{
    public interface ITextField<out TResult> : IUIElement, IHasText where TResult : Block
    {
        TResult EnterText(string text);
    }
}