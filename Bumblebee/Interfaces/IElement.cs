using Bumblebee.Setup;

namespace Bumblebee.Interfaces
{
	public interface IElement : IDraggable, IHasParent
	{
		Session Session { get; }
	}
}
