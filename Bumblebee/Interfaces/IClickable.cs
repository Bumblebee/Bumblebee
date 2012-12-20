using Bumblebee.Interfaces.Conditional;

namespace Bumblebee.Interfaces
{
    public interface IClickable<out TResult> : IConditionalClickable where TResult : IBlock
    {
        TResult Click();
    }
}
