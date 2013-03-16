namespace Bumblebee.Interfaces
{
    public interface IAllowsNoOp
    {
        TCustomResult Then<TCustomResult>() where TCustomResult : IBlock;
    }

    public interface IAllowsNoOp<out TResult> : IAllowsNoOp where TResult : IBlock
    {
        TResult Then();
    }
}
