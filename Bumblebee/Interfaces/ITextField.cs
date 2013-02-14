namespace Bumblebee.Interfaces
{
    public interface ITextField<out TResult> : IElement, IHasText where TResult : IBlock
    {
        TResult EnterText(string text);
        TResult AppendText(string text);
    }
}