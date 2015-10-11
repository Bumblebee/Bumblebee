using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;
using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	/// <summary>
	/// Represents a set of elements of the same type.
	/// </summary>
	/// <typeparam name="TElement">The type of elements must implement the IElement interface.</typeparam>
	public class Elements<TElement> : IEnumerable<TElement>
		where TElement : IElement
	{
		private readonly IBlock _parent;
		private readonly By _by;
		private readonly TimeSpan _timeout;

		/// <summary>
		/// To construct a set of Elements, you must have both a parent block and a specification for finding the elements.
		/// </summary>
		/// <param name="parent">The parent block.</param>
		/// <param name="by">The specification for finding the elements.</param>
		/// <param name="timeout">The time period that the driver should wait when finding the elements; this is optional.</param>
		public Elements(IBlock parent, By @by, TimeSpan? timeout = null)
		{
			_parent = parent;
			_by = @by;
			_timeout = timeout ?? TimeSpan.FromSeconds(0);
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<TElement> GetEnumerator()
		{
			return _parent
				.FindElements(_by)
				.Select((element, index) => Element.Create<TElement>(_parent, new ByOrdinal(_by, index)))
				.GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
