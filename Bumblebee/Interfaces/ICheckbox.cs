namespace Bumblebee.Interfaces
{
    public interface ICheckbox<out TResult> : IElement, ISelectable where TResult : IBlock
    {
        TResult Check();
        TResult Uncheck();
        TResult Toggle();
    }
}