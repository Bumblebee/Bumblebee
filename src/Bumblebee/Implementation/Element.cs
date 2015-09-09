using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public abstract class Element : IElement
	{
		public IBlock ParentBlock { get; private set; }
		public IWebElement Tag { get; private set; }
		public Session Session { get; private set; }

		public virtual string Text { get { return Tag.Text; } }
		public virtual bool Selected { get { return Tag.Selected; } }

		protected Element(IBlock parent, By @by) : this(parent, parent.FindElement(@by))
		{
		}

		protected Element(IBlock parent, IWebElement tag)
		{
			ParentBlock = parent;
			Session = parent.Session;
			Tag = tag;
		}

		public TParent ParentAs<TParent>() where TParent : IBlock
		{
			var type = typeof (TParent);

			var result = default (TParent);

			if (type.IsInstanceOfType(ParentBlock))
			{
				result = (TParent)ParentBlock;
			}

			return result;
		}

		public IPerformsDragAndDrop GetDragAndDropPerformer()
		{
			return new WebDragAndDropPerformer(Session.Driver);
		}
	}
}
