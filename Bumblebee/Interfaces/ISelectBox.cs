using System.Collections.Generic;

namespace Bumblebee.Interfaces
{
    public interface ISelectBox<out TResult> : IElement where TResult : IBlock
    {
        IEnumerable<IOption<TResult>> Options { get; }
    }
}
