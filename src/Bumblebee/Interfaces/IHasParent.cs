namespace Bumblebee.Interfaces
{
	public interface IHasParent : IHasBackingElement
	{
		IBlock ParentBlock { get; }
		TParent ParentAs<TParent>() where TParent : IBlock;
	}
}
