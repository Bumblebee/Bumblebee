namespace Bumblebee.Interfaces
{
	/// <summary>
	/// Interface for block or element which can have focus.
	/// </summary>
	public interface IFocusable
	{
		/// <summary>
		/// Sets focus on the block or element.
		/// </summary>
		/// <typeparam name="TResult">The type of the block the focused block or element is on.</typeparam>
		/// <returns>The type of block to return.</returns>
		TResult SetFocus<TResult>() where TResult : IBlock;

		/// <summary>
		/// Gets the value indicating whether block or element has focus.
		/// </summary>
		bool HasFocus { get; }
	}

	/// <summary>
	/// Interface for block or element which can have focus.
	/// </summary>
	/// <typeparam name="TResult">The type of the block the focused block or element is on.</typeparam>
	public interface IFocusable<out TResult> : IFocusable
		where TResult : IBlock
	{
		/// <summary>
		/// Sets focus on the block or element.
		/// </summary>
		/// <returns>The type of block to return.</returns>
		TResult SetFocus();
	}
}