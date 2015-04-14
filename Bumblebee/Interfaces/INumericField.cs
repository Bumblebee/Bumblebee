namespace Bumblebee.Interfaces
{
	/// <summary>
	/// An input[type='number'] in a browser.
	/// </summary>
	public interface INumericField : ITextField
	{
		/// <summary>
		/// Enters a number into the number field
		/// </summary>
		/// <typeparam name="TCustomResult">The type of the block this element is on.</typeparam>
		/// <param name="number">The number to enter</param>
		/// <returns>The current block</returns>
		TCustomResult EnterNumber<TCustomResult>(double number) where TCustomResult : IBlock;

		/// <summary>
		/// Gets the value as a double. Tries to parse according to CurrentUICulture.
		/// </summary>
		/// <value>
		/// The value as a double or null if it couldn't be parsed.
		/// </value>
		double? Value { get; }
	}

	/// <summary>
	/// An input[type='number'] in a browser.
	/// </summary>
	/// <typeparam name="TResult">The type of the block this element is on.</typeparam>
	public interface INumericField<out TResult> : INumericField, ITextField<TResult>
		where TResult : IBlock
	{
		/// <summary>
		/// Enters a number into the number field
		/// </summary>
		/// <param name="number">The number to enter</param>
		/// <returns>The current block</returns>
		TResult EnterNumber(double number);
	}
}
