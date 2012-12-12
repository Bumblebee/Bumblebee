using Bumblebee.Implementation;

namespace Bumblebee.Interfaces.Conditional
{
    public interface IConditionalClickable : IElement, IHasText
    {
        TResult Click<TResult>() where TResult : IBlock;
    }
}
