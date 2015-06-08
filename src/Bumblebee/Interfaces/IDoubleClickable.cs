namespace Bumblebee.Interfaces
{
	/// <summary>
	/// Element that is double-clickable with a static page return.
	/// </summary>
	public interface IDoubleClickable : IClickable, IElement, IHasText
	{
		TResult DoubleClick<TResult>() where TResult : IBlock;
	}

	/// <summary>
	/// Element that is double-clickable with a dynamic page return.
	/// </summary>
	/// <typeparam name="TResult">The type of page to return.</typeparam>
	public interface IDoubleClickable<out TResult> : IClickable<TResult>, IDoubleClickable
		where TResult : IBlock
	{
		TResult DoubleClick();
	}
}
