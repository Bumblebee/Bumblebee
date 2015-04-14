namespace Bumblebee.Interfaces
{
	public interface IGenericElement<out TResult> : IElement
		where TResult : IBlock
	{
	}
}
