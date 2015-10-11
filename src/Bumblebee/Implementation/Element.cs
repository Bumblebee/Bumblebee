using System;

using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Specifications;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Implementation
{
	/// <summary>
	/// Element is a base class for all simple elements on a given page such as buttons, text inputs, links, etc.
	/// </summary>
	public abstract class Element : IElement
	{
		protected static readonly ISpecification By = new Specification();

		/// <summary>
		/// The text for the given element.
		/// </summary>
		public virtual string Text { get { return Tag.Text; } }

		/// <summary>
		/// Determines if the element is select or not.
		/// </summary>
		public virtual bool Selected { get { return Tag.Selected; } }

		/// <summary>
		/// The Element requires both a parent block and a specification for finding it.
		/// </summary>
		/// <param name="parent">The parent block.</param>
		/// <param name="by">The specification for finding the element.</param>
		/// <param name="timeout">The amount of time the driver should wait to find an element; it is optional.</param>
		/// <exception cref="ArgumentNullException">
		/// parent
		/// or
		/// by
		/// </exception>
		protected Element(IBlock parent, By @by, TimeSpan? timeout = null)
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}

			if (@by == null)
			{
				throw new ArgumentNullException("by");
			}

			Parent = parent;
			Session = parent.Session;
			Specification = @by;
			Wait = timeout.HasValue ? new WebDriverWait(Session.Driver, timeout.Value) : new WebDriverWait(Session.Driver, TimeSpan.FromSeconds(0));
		}

		/// <summary>
		/// Allows for the creation of a derived Element based on a parent Block and By specification using reflection.
		/// </summary>
		/// <typeparam name="TElement">The type of the element.</typeparam>
		/// <param name="parent">The parent.</param>
		/// <param name="by">The specification for finding the element.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public static TElement Create<TElement>(IBlock parent, By @by) where TElement : IElement
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}

			if (@by == null)
			{
				throw new ArgumentNullException("by");
			}

			var type = typeof(TElement);
			var ctor = type.GetConstructor(new[] { typeof(IBlock), typeof(By) });

			if (ctor == null)
			{
				throw new ArgumentException(String.Format("The specified type ({0}) is not a valid element. It must have a constructor that takes an IBlock parent and a By specification.", type));
			}

			var result = (TElement)ctor.Invoke(new object[] { parent, @by });

			return result;
		}

		/// <summary>
		/// Allows for the creation of a derived Element based on a parent Block and By specification using reflection.
		/// </summary>
		/// <typeparam name="TElement">The type of the element.</typeparam>
		/// <param name="parent">The parent.</param>
		/// <param name="by">The specification for finding the element.</param>
		/// <param name="timeout">The timeout period when trying to find an element.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">
		/// parent
		/// or
		/// by
		/// </exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public static TElement Create<TElement>(IBlock parent, By @by, TimeSpan timeout) where TElement : IElement
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}

			if (@by == null)
			{
				throw new ArgumentNullException("by");
			}

			var type = typeof(TElement);
			var ctor = type.GetConstructor(new[] { typeof(IBlock), typeof(By), typeof(TimeSpan) });

			if (ctor == null)
			{
				throw new ArgumentException(String.Format("The specified type ({0}) is not a valid element. It must have a constructor that takes an IBlock parent, By specification, and TimeSpan timeout.", type));
			}

			var result = (TElement)ctor.Invoke(new object[] { parent, @by, timeout });

			return result;
		}

		/// <summary>
		/// The parent block.
		/// </summary>
		public IBlock Parent { get; private set; }

		/// <summary>
		/// The current session.
		/// </summary>
		public Session Session { get; private set; }

		private By Specification { get; set; }

		/// <summary>
		/// A common wait timeout that can be used when trying to find the Tag element.
		/// </summary>
		protected WebDriverWait Wait { get; set; }

		/// <summary>
		/// The actual web element that the Element is abstracting.
		/// </summary>
		public IWebElement Tag
		{
			get
			{
				return Wait.Until(driver => Parent.FindElement(Specification));
			}
		}

		/// <summary>
		/// Convenience method for getting the drag and drop performer action.
		/// </summary>
		/// <returns></returns>
		public virtual IPerformsDragAndDrop GetDragAndDropPerformer()
		{
			return new WebDragAndDropPerformer(Session.Driver);
		}
	}
}
