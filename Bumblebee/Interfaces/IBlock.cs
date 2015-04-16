using Bumblebee.Setup;

namespace Bumblebee.Interfaces
{
	public interface IBlock : IDraggable, IMonkeyable, IHasParent
	{
		Session Session { get; }
	}
}
