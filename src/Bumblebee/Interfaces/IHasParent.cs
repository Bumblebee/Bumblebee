namespace Bumblebee.Interfaces
{
	public interface IHasParent : IHasBackingElement
	{
		IBlock Parent { get; }
		TParent ParentAs<TParent>() where TParent : IBlock;
	}
}
