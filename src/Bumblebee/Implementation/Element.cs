using System;

using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public abstract class Element : IElement
	{
		protected static readonly ISpecification By = null;

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

		public virtual IPerformsDragAndDrop GetDragAndDropPerformer()
		{
			return new WebDragAndDropPerformer(Session.Driver);
		}
	}
}
