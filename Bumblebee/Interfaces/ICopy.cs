namespace Bumblebee.Interfaces
{
    public interface ICopy<out TResult> : IAllowsNoOp<TResult>, IHasText where TResult : IBlock
    {
    }
}