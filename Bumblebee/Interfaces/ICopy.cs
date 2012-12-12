using Bumblebee.Implementation;

namespace Bumblebee.Interfaces
{
    public interface ICopy<out TResult> : IElement, IHasText where TResult : IBlock
    {
        TResult VerifyContent(string text);
    }
}