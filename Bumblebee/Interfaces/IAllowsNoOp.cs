namespace Bumblebee.Interfaces
{

    public interface IAllowsNoOp<out TResult> : IGenericElement<TResult> where TResult : IBlock
    {
    }
}
