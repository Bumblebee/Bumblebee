using System.Collections.Generic;

namespace Bumblebee.Interfaces
{
	/// <summary>
	/// Provides an abstraction for &lt;select&gt; elements.
	/// </summary>
	public interface ISelectBox : IBlock
	{
		/// <summary>
		/// Gets all &lt;option&gt; elements.
		/// </summary>
		IEnumerable<IOption> Options { get; }

		/// <summary>
		/// Gets the first selected &lt;option&gt; element.
		/// </summary>
		IOption SelectedOption { get; }

		/// <summary>
		/// Gets all selected &lt;option&gt; elements.
		/// </summary>
		IEnumerable<IOption> SelectedOptions { get; }

		/// <summary>
		/// Gets whether or not this &lt;select&gt; element supports multiple selections.
		/// </summary>
		bool IsMultiSelect { get; }

		/// <summary>
		/// Select the &lt;option&gt; element with the specified text.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="text">The text to search for. If an exact match is not found, this method will perform a substring match.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult SelectByText<TResult>(string text) where TResult : IBlock;

		/// <summary>
		/// Select the &lt;option&gt; element with the specified value.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="value">The value to search for.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult SelectByValue<TResult>(string value) where TResult : IBlock;

		/// <summary>
		/// Select the &lt;option&gt; element with the specified index, as determined by the "index" attribute.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="index">The index of the element to select.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult SelectByIndex<TResult>(int index) where TResult : IBlock;

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified text.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="text">The text to search for. If an exact match is not found, this method will perform a substring match.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult DeselectByText<TResult>(string text) where TResult : IBlock;

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified value.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="value">The value to search for.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult DeselectByValue<TResult>(string value) where TResult : IBlock;

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified index, as determined by the "index" attribute.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="index">The index of the element to select.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult DeselectByIndex<TResult>(int index) where TResult : IBlock;

		/// <summary>
		/// Clear all selected options. This is only valid when this &lt;select&gt; element supports multiple selections.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult DeselectAll<TResult>() where TResult : IBlock;
	}

	/// <summary>
	/// Provides an abstraction for &lt;select&gt; elements.
	/// </summary>
	public interface ISelectBox<out TResult> : ISelectBox
		where TResult : IBlock
	{
		/// <summary>
		/// Gets all &lt;option&gt; elements.
		/// </summary>
		IEnumerable<IOption<TResult>> Options { get; }

		/// <summary>
		/// Gets the first selected &lt;option&gt; elements.
		/// </summary>
		IOption<TResult> SelectedOption { get; }

		/// <summary>
		/// Gets all selected &lt;option&gt; elements.
		/// </summary>
		IEnumerable<IOption<TResult>> SelectedOptions { get; }

		/// <summary>
		/// Select the &lt;option&gt; element with the specified text.
		/// </summary>
		/// <param name="text">The text to search for. If an exact match is not found, this method will perform a substring match.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult SelectByText(string text);

		/// <summary>
		/// Select the &lt;option&gt; element with the specified value.
		/// </summary>
		/// <param name="value">The value to search for.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult SelectByValue(string value);

		/// <summary>
		/// Select the &lt;option&gt; element with the specified index, as determined by the "index" attribute.
		/// </summary>
		/// <param name="index">The index of the element to select.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult SelectByIndex(int index);

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified text.
		/// </summary>
		/// <param name="text">The text to search for. If an exact match is not found, this method will perform a substring match.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult DeselectByText(string text);

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified value.
		/// </summary>
		/// <param name="value">The value to search for.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult DeselectByValue(string value);

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified index, as determined by the "index" attribute.
		/// </summary>
		/// <param name="index">The index of the element to select.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult DeselectByIndex(int index);

		/// <summary>
		/// Clear all selected options. This is only valid when this &lt;select&gt; element supports multiple selections.
		/// </summary>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		TResult DeselectAll();
	}
}
