using System.Collections.Generic;

namespace Bumblebee.UI.Conditional
{
    public interface IConditionalSelectBox : IUIElement
    {
        IEnumerable<IConditionalOption> Options { get; }
    }
}