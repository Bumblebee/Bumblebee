namespace Bumblebee.Interfaces
{
	public interface IHasParent : IHasBackingElement
	{
		IBlock ParentBlock { get; }
	}
}
