using System;

using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public abstract class Element : IElement
	{
		protected static readonly ISpecification By = new Specification();

		public IBlock Parent { get; private set; }
		public Session Session { get; private set; }

		public IWebElement Tag { get; private set; }

		public virtual string Text { get { return Tag.Text; } }
		public virtual bool Selected { get { return Tag.Selected; } }

		protected Element(IBlock parent, By @by) : this(parent, parent.FindElement(@by))
		{
		}

		protected Element(IBlock parent, IWebElement tag)
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}

			if (tag == null)
			{
				throw new ArgumentNullException("tag");
			}

			Parent = parent;
			Session = parent.Session;
			Tag = tag;
		}

		/// <summary>
		/// Allows for the creation of a derived Element based on a parent Block and By specification using reflection.
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="by"></param>
		/// <typeparam name="Element"></typeparam>
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
		/// Allows for the creation of a derived Element based on a parent Block and IWebElement element using reflection.
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="element"></param>
		/// <typeparam name="TElement"></typeparam>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public static TElement Create<TElement>(IBlock parent, IWebElement element) where TElement : IElement
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}

			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

			var type = typeof(TElement);
			var ctor = type.GetConstructor(new[] { typeof(IBlock), typeof(IWebElement) });

			if (ctor == null)
			{
				throw new ArgumentException(String.Format("The specified type ({0}) is not a valid element. It must have a constructor that takes an IBlock parent and a IWebElement backing element.", type));
			}

			var result = (TElement)ctor.Invoke(new object[] { parent, element });

			return result;
		}

		public virtual IPerformsDragAndDrop GetDragAndDropPerformer()
		{
			return new WebDragAndDropPerformer(Session.Driver);
		}
	}
}
