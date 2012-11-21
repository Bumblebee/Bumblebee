namespace Bumblebee.Interfaces
{
    public interface ICopy<out TResult> : IElement, IHasText where TResult : Block
    {
        TResult VerifyContent(string text);
    }
}