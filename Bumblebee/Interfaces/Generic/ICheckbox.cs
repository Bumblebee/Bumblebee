using Bumblebee.Implementation;

namespace Bumblebee.Interfaces.Generic
{
    public interface ICheckbox<out TResult> : IElement, ISelectable where TResult : IBlock
    {
        TResult Check();
        TResult Uncheck();
        TResult Toggle();
    }
}