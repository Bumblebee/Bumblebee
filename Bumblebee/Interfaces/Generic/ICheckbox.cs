namespace Bumblebee.Interfaces.Generic
{
    public interface ICheckbox<out TResult> : IElement, ISelectable where TResult : Block
    {
        TResult Check();
        TResult Uncheck();
        TResult Toggle();
    }
}