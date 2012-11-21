namespace Bumblebee.UI.Generic
{
    public interface ICheckbox<out TResult> : IUIElement, ISelectable where TResult : Block
    {
        TResult Check();
        TResult Uncheck();
        TResult Toggle();
    }
}