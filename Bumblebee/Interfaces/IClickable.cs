using Bumblebee.Implementation;
using Bumblebee.Interfaces.Conditional;

namespace Bumblebee.Interfaces.Generic
{
    public interface IClickable<out TResult> : IConditionalClickable where TResult : IBlock
    {
        TResult Click();
    }
}
