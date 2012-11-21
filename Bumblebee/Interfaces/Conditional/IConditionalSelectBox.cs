using System.Collections.Generic;

namespace Bumblebee.Interfaces.Conditional
{
    public interface IConditionalSelectBox : IElement
    {
        IEnumerable<IConditionalOption> Options { get; }
    }
}