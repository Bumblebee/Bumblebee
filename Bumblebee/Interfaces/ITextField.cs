namespace Bumblebee.Interfaces
{
    public interface ITextField : IElement, IHasText
    {
        TCustomResult EnterText<TCustomResult>(string text) where TCustomResult : IBlock;
        TCustomResult AppendText<TCustomResult>(string text) where TCustomResult : IBlock;
    }

    public interface ITextField<out TResult> : ITextField, IAllowsNoOp<TResult> where TResult : IBlock
    {
        TResult EnterText(string text);
        TResult AppendText(string text);
    }
}