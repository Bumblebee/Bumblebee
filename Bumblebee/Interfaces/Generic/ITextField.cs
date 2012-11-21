namespace Bumblebee.Interfaces.Generic
{
    public interface ITextField<out TResult> : IElement, IHasText where TResult : Block
    {
        TResult EnterText(string text);
    }
}