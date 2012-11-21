using System.Collections.Generic;

namespace Bumblebee.Interfaces.Generic
{
    public interface ISelectBox<out TResult> : IElement where TResult : Block
    {
        IEnumerable<IOption<TResult>> Options { get; }
    }
}
