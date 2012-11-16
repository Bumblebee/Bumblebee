using System.Collections.Generic;

namespace Bumblebee.UI.Generic
{
    public interface ISelectBox<out TResult> : IUIElement where TResult : Block
    {
        IEnumerable<IClickable<TResult>> Options { get; }
    }
}