using System;

namespace Bumblebee.Interfaces
{
	/// <summary>
	/// An input[type='date'] in a browser.
	/// </summary>
	public interface IDateField : ITextField
	{
		/// <summary>
		/// Enters a date into the date field
		/// </summary>
		/// <typeparam name="TCustomResult">The type of the block this element is on.</typeparam>
		/// <param name="date">The date to enter</param>
		/// <returns>The current block</returns>
		TCustomResult EnterDate<TCustomResult>(DateTime date) where TCustomResult : IBlock;

		/// <summary>
		/// Gets the value as a DateTime. Tries to parse according to CurrentUICulture.
		/// </summary>
		/// <value>
		/// The value as a DateTime or null if it couldn't be parsed.
		/// </value>
		DateTime? Value { get; }
	}

	/// <summary>
	/// An input[type='date'] in a browser.
	/// </summary>
	/// <typeparam name="TResult">The type of the block this element is on.</typeparam>
	public interface IDateField<out TResult> : IDateField, ITextField<TResult>
		where TResult : IBlock
	{
		/// <summary>
		/// Enters a date into the date field
		/// </summary>
		/// <param name="date">The date to enter</param>
		/// <returns>The current block</returns>
		TResult EnterDate(DateTime date);
	}
}
