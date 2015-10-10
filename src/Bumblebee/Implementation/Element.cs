using System;

using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Specifications;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Implementation
{
	public abstract class Element : IElement
	{
		protected static readonly ISpecification By = new Specification();

		public virtual string Text { get { return Tag.Text; } }
		public virtual bool Selected { get { return Tag.Selected; } }

		protected Element(IBlock parent, By @by)
			: this(parent, by, null)
		{
		}

		protected Element(IBlock parent, By @by, TimeSpan? timeout)
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
			Wait = timeout.HasValue ? new WebDriverWait(Session.Driver, timeout.Value) : null;
		}

		/// <summary>
		/// Allows for the creation of a derived Element based on a parent Block and By specification using reflection.
		/// </summary>
		/// <typeparam name="Element">The type of the element.</typeparam>
		/// <param name="parent">The parent.</param>
		/// <param name="by">The specification for finding the element.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public static Element Create<Element>(IBlock parent, By @by) where Element : IElement
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}

			if (@by == null)
			{
				throw new ArgumentNullException("by");
			}

			var type = typeof(Element);
			var ctor = type.GetConstructor(new[] { typeof(IBlock), typeof(By) });

			if (ctor == null)
			{
				throw new ArgumentException(String.Format("The specified type ({0}) is not a valid element. It must have a constructor that takes an IBlock parent and a By specification.", type));
			}

			var result = (Element)ctor.Invoke(new object[] { parent, @by });

			return result;
		}

		/// <summary>
		/// Allows for the creation of a derived Element based on a parent Block and By specification using reflection.
		/// </summary>
		/// <typeparam name="Element">The type of the element.</typeparam>
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
		public static Element Create<Element>(IBlock parent, By @by, TimeSpan timeout) where Element : IElement
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}

			if (@by == null)
			{
				throw new ArgumentNullException("by");
			}

			var type = typeof(Element);
			var ctor = type.GetConstructor(new[] { typeof(IBlock), typeof(By), typeof(TimeSpan) });

			if (ctor == null)
			{
				throw new ArgumentException(String.Format("The specified type ({0}) is not a valid element. It must have a constructor that takes an IBlock parent, By specification, and TimeSpan timeout.", type));
			}

			var result = (Element)ctor.Invoke(new object[] { parent, @by, timeout });

			return result;
		}

		public IBlock Parent { get; private set; }
		public Session Session { get; private set; }

		private By Specification { get; set; }

		private WebDriverWait Wait { get; set; }

		public IWebElement Tag
		{
			get
			{
				return Wait == null
					? Parent.FindElement(Specification)
					: Wait.Until(driver => Parent.FindElement(Specification));
			}
		}

		public virtual IPerformsDragAndDrop GetDragAndDropPerformer()
		{
			return new WebDragAndDropPerformer(Session.Driver);
		}
	}
}
