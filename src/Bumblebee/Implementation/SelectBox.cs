using System.Collections.Generic;
using System.Linq;

using Bumblebee.Extensions;
using Bumblebee.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Implementation
{
	/// <summary>
	/// Provides an abstraction for &lt;select&gt; elements.
	/// </summary>
	public class SelectBox : Block, ISelectBox
	{
		/// <summary>
		/// Gets a new instance of <see cref="OpenQA.Selenium.Support.UI.SelectElement" /> for use in member methods.
		/// </summary>
		protected SelectElement SelectElement => new SelectElement(Tag);

		/// <summary>
		/// Initializes a new instance of the <see cref="SelectBox" /> class. To construct a <see cref="SelectBox" />, you must have both a parent block and a specification for finding the &lt;select&gt; element.
		/// </summary>
		/// <param name="parent">The parent block.</param>
		/// <param name="by">The specification for finding this block.</param>
		public SelectBox(IBlock parent, By @by) : base(parent, @by)
		{
		}

		/// <summary>
		/// Gets all &lt;option&gt; elements.
		/// </summary>
		public virtual IEnumerable<IOption> Options => FindElements<Option>(By.TagName("option"));

		/// <summary>
		/// Gets the first selected &lt;option&gt; element.
		/// </summary>
		public IOption SelectedOption => SelectedOptions.FirstOrDefault();

		/// <summary>
		/// Gets all selected &lt;option&gt; elements.
		/// </summary>
		public IEnumerable<IOption> SelectedOptions
		{
			get
			{
				var index = 0;

				foreach (var element in SelectElement.Options)
				{
					if (element.Selected)
					{
						yield return Element.Create<Option>(this, By.Ordinal(By.TagName("option"), index));
					}

					index++;
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether this &lt;select&gt; element supports multiple selections.
		/// </summary>
		public bool IsMultiSelect => SelectElement.IsMultiple;

		/// <summary>
		/// Select the &lt;option&gt; element with the specified text.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="text">The text to search for. If an exact match is not found, this method will perform a substring match.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult SelectByText<TResult>(string text) where TResult : IBlock
		{
			SelectElement.SelectByText(text);

			return this.FindRelated<TResult>();
		}

		/// <summary>
		/// Select the &lt;option&gt; element with the specified value.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="value">The value to search for.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult SelectByValue<TResult>(string value) where TResult : IBlock
		{
			SelectElement.SelectByValue(value);

			return this.FindRelated<TResult>();
		}

		/// <summary>
		/// Select the &lt;option&gt; element with the specified index, as determined by the "index" attribute.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="index">The index of the element to select.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult SelectByIndex<TResult>(int index) where TResult : IBlock
		{
			SelectElement.SelectByIndex(index);

			return this.FindRelated<TResult>();
		}

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified text.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="text">The text to search for. If an exact match is not found, this method will perform a substring match.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult DeselectByText<TResult>(string text) where TResult : IBlock
		{
			SelectElement.DeselectByText(text);

			return this.FindRelated<TResult>();
		}

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified value.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="value">The value to search for.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult DeselectByValue<TResult>(string value) where TResult : IBlock
		{
			SelectElement.DeselectByValue(value);

			return this.FindRelated<TResult>();
		}

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified index, as determined by the "index" attribute.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <param name="index">The index of the element to select.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult DeselectByIndex<TResult>(int index) where TResult : IBlock
		{
			SelectElement.DeselectByIndex(index);

			return this.FindRelated<TResult>();
		}

		/// <summary>
		/// Clear all selected options. This is only valid when this &lt;select&gt; element supports multiple selections.
		/// </summary>
		/// <typeparam name="TResult">The type of block to return.</typeparam>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult DeselectAll<TResult>() where TResult : IBlock
		{
			SelectElement.DeselectAll();

			return this.FindRelated<TResult>();
		}

		/// <summary>
		/// Sets focus on the select box.
		/// </summary>
		/// <typeparam name="TResult">The type of the block the focused block or element is on.</typeparam>
		/// <returns>The type of block to return.</returns>
		public TResult SetFocus<TResult>() where TResult : IBlock
		{
			Session.Driver.ExecuteJavaScript("arguments[0].focus();", Tag);
			return this.FindRelated<TResult>();
		}

		/// <summary>
		/// Gets the value indicating whether the select box has focus.
		/// </summary>
		public bool HasFocus => Tag.Equals(Session.Driver.SwitchTo().ActiveElement());
	}

	/// <summary>
	/// Provides a generic abstraction for &lt;select&gt; elements.
	/// </summary>
	/// <typeparam name="TResult">The type of block all actions will return.</typeparam>
	public class SelectBox<TResult> : SelectBox, ISelectBox<TResult> where TResult : IBlock
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SelectBox{TResult}" /> class. To construct a <see cref="SelectBox" />, you must have both a parent block and a specification for finding the &lt;select&gt; element.
		/// </summary>
		/// <param name="parent">The parent block.</param>
		/// <param name="by">The specification for finding this block.</param>
		public SelectBox(IBlock parent, By @by) : base(parent, @by)
		{
		}

		/// <summary>
		/// Gets all &lt;option&gt; elements.
		/// </summary>
		public new virtual IEnumerable<IOption<TResult>> Options => FindElements<Option<TResult>>(By.TagName("option"));

		/// <summary>
		/// Gets the first selected &lt;option&gt; element.
		/// </summary>
		public new IOption<TResult> SelectedOption => SelectedOptions.FirstOrDefault();

		/// <summary>
		/// Gets all selected &lt;option&gt; elements.
		/// </summary>
		public new IEnumerable<IOption<TResult>> SelectedOptions
		{
			get
			{
				var index = 0;

				foreach (var element in SelectElement.Options)
				{
					if (element.Selected)
					{
						yield return Element.Create<Option<TResult>>(this, By.Ordinal(By.TagName("option"), index));
					}

					index++;
				}
			}
		}

		/// <summary>
		/// Select the &lt;option&gt; element with the specified text.
		/// </summary>
		/// <param name="text">The text to search for. If an exact match is not found, this method will perform a substring match.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult SelectByText(string text)
		{
			return SelectByText<TResult>(text);
		}

		/// <summary>
		/// Select the &lt;option&gt; element with the specified value.
		/// </summary>
		/// <param name="value">The value to search for.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult SelectByValue(string value)
		{
			return SelectByValue<TResult>(value);
		}

		/// <summary>
		/// Select the &lt;option&gt; element with the specified index, as determined by the "index" attribute.
		/// </summary>
		/// <param name="index">The index of the element to select.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult SelectByIndex(int index)
		{
			return SelectByIndex<TResult>(index);
		}

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified text.
		/// </summary>
		/// <param name="text">The text to search for. If an exact match is not found, this method will perform a substring match.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult DeselectByText(string text)
		{
			return DeselectByText<TResult>(text);
		}

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified value.
		/// </summary>
		/// <param name="value">The value to search for.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult DeselectByValue(string value)
		{
			return DeselectByValue<TResult>(value);
		}

		/// <summary>
		/// Deselect the &lt;option&gt; element with the specified index, as determined by the "index" attribute.
		/// </summary>
		/// <param name="index">The index of the element to select.</param>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult DeselectByIndex(int index)
		{
			return DeselectByIndex<TResult>(index);
		}

		/// <summary>
		/// Clear all selected options. This is only valid when this &lt;select&gt; element supports multiple selections.
		/// </summary>
		/// <returns>The closest related element of type <typeparamref name="TResult" />.</returns>
		public TResult DeselectAll()
		{
			return DeselectAll<TResult>();
		}

		/// <summary>
		/// Sets focus on the select box.
		/// </summary>
		/// <returns>The type of block to return.</returns>
		public TResult SetFocus()
		{
			return SetFocus<TResult>();
		}
	}
}