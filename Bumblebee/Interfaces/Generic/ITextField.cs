using Bumblebee.Implementation;

namespace Bumblebee.Interfaces.Generic
{
    public interface ITextField<out TResult> : IElement, IHasText where TResult : IBlock
    {
        TResult EnterText(string text);
    }
}