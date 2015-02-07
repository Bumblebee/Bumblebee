using Bumblebee.Setup;

namespace Bumblebee.Interfaces
{
    public interface IElement : IDraggable
    {
        Session Session { get; }
    }
}
