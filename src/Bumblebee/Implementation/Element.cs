using System;

using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	/// <summary>
	/// Element is a base class for all simple elements on a given page such as buttons, text inputs, links, etc.
	/// </summary>
	public abstract class Element : IElement
	{
		protected static readonly ISpecification By = new Specification();

		/// <summary>
		/// Gets the text for the given element.
		/// </summary>
		public virtual string Text => Tag.Text;

		/// <summary>
		/// Gets whether the element is selected or not.
		/// </summary>
		public virtual bool Selected => Tag.Selected;

		/// <summary>
		/// The Element requires both a parent block and a specification for finding it.
		/// </summary>
		/// <param name="parent">The parent block.</param>
		/// <param name="by">The specification for finding the element.</param>
		/// <exception cref="ArgumentNullException">
		/// parent
		/// or
		/// by
		/// </exception>
		protected Element(IBlock parent, By @by)
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
		}

		/// <summary>
		/// Allows for the creation of a derived Element based on a parent Block and By specification using reflection.
		/// </summary>
		/// <typeparam name="TElement">The type of the element.</typeparam>
		/// <param name="parent">The parent.</param>
		/// <param name="by">The specification for finding the element.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">
		/// parent
		/// or
		/// by
		/// </exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public static TElement Create<TElement>(IBlock parent, By @by) where TElement : IElement
		{
			if (parent == null)
			{
				throw new ArgumentNullException(nameof (parent));
			}

			if (@by == null)
			{
				throw new ArgumentNullException(nameof (@by));
			}

			var type = typeof (TElement);
			var ctor = type.GetConstructor(new[] { typeof (IBlock), typeof (By) });

			TElement result;

			if (ctor != null)
			{
				result = (TElement) ctor.Invoke(new object[] { parent, @by });
			}
			else
			{
				throw new ArgumentException($"The specified type ({type}) is not a valid element. It must have a constructor that takes an IBlock parent and a By specification.");
			}

			return result;
		}

		/// <summary>
		/// Gets the parent block.
		/// </summary>
		public IBlock Parent { get; }

		/// <summary>
		/// Gets the current session.
		/// </summary>
		public Session Session { get; }

		private By Specification { get; }

		/// <summary>
		/// Gets the Selenium IWebElement that underpins this component.
		/// </summary>
		public IWebElement Tag => Parent.FindElement(Specification);

		/// <summary>
		/// Gets the value of the specified attribute for this component.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <returns>The value of the attribute.</returns>
		public virtual string GetAttribute(string name)
		{
			return Tag.GetAttribute(name);
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
