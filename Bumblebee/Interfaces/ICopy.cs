using Bumblebee.Implementation;

namespace Bumblebee.Interfaces
{
    public interface ICopy<out TResult> : IElement, IAllowsNoOp<TResult>, IHasText where TResult : IBlock
    {
    }
}