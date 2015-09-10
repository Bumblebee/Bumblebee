using System.Collections.Generic;

using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public abstract class Block : IBlock
	{
		public IBlock Parent { get; private set; }
		public Session Session { get; private set; }
		public By Specification { get; private set; }

		public virtual IWebElement Tag
		{
			get
			{
				IWebElement result;

				if (Parent == null)
				{
					result = Session.Driver
						.SwitchTo()
						.DefaultContent()
						.FindElement(Specification);
				}
				else
				{
					result = Parent
						.FindElement(Specification);
				}

				return result;
			}
		}

		protected Block(Session session, By @by)
		{
			Session = session;
			Specification = @by;

			if (Session.Monkey != null)
			{
				Session.Monkey.Invoke(this);
			}
		}

		protected Block(IBlock parent, By @by)
		{
			Session = parent.Session;
			Specification = @by;
			Parent = parent;

			if (Session.Monkey != null)
			{
				Session.Monkey.Invoke(this);
			}
		}

		public TParent ParentAs<TParent>() where TParent : IBlock
		{
			var type = typeof (TParent);

			var result = default (TParent);

			if (type.IsInstanceOfType(Parent))
			{
				result = (TParent) Parent;
			}

			return result;
		}

		public virtual IEnumerable<IWebElement> FindElements(By @by)
		{
			return Tag.FindElements(@by);
		}

		public virtual IWebElement FindElement(By @by)
		{
			return Tag.FindElement(@by);
		}

		public virtual IPerformsDragAndDrop GetDragAndDropPerformer()
		{
			return new WebDragAndDropPerformer(Session.Driver);
		}

		public virtual void VerifyMonkeyState()
		{
		}
	}
}
