namespace Bumblebee.Interfaces
{
    public interface ICheckbox : IElement, ISelectable
    {
        TCustomResult Check<TCustomResult>() where TCustomResult : IBlock;
        TCustomResult Uncheck<TCustomResult>() where TCustomResult : IBlock;
        TCustomResult Toggle<TCustomResult>() where TCustomResult : IBlock;
    }

    public interface ICheckbox<out TResult> : ICheckbox where TResult : IBlock
    {
        TResult Check();
        TResult Uncheck();
        TResult Toggle();
    }
}