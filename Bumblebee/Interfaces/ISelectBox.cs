using System.Collections.Generic;
using Bumblebee.Implementation;

namespace Bumblebee.Interfaces.Generic
{
    public interface ISelectBox<out TResult> : IElement where TResult : IBlock
    {
        IEnumerable<IOption<TResult>> Options { get; }
    }
}
