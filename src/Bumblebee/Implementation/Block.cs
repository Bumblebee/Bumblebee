using System;
using System.Collections.Generic;

using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public abstract class Block : IBlock
	{
		protected static readonly ISpecification By = null;

		internal Block(Session session, By @by) : this(session)
		{
			if (session == null)
			{
				throw new ArgumentNullException("session");
			}

			if (@by == null)
			{
				throw new ArgumentNullException("by");
			}

			Session = session;
			Specification = @by;

			if (Session.Monkey != null)
			{
				Session.Monkey.Invoke(this);
			}
		}

		protected Block(IBlock parent, By @by) : this(parent.Session)
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

			if (Session.Monkey != null)
			{
				Session.Monkey.Invoke(this);
			}
		}

		private Block(Session session)
		{
			session.SetCurrentBlock(this);
		}

		public IBlock Parent { get; private set; }

		public Session Session { get; private set; }

		public By Specification { get; private set; }

		public virtual IWebElement Tag
		{
			get
			{
				return Parent.FindElement(Specification);
			}
		}

		public virtual IWebElement FindElement(By @by)
		{
			return Tag.FindElement(@by);
		}

		public virtual IEnumerable<IWebElement> FindElements(By @by)
		{
			return Tag.FindElements(@by);
		}

		[Obsolete("This method is obsolete. Please use FindElement(By @by) instead.", error: true)]
		public virtual IWebElement GetElement(By @by)
		{
			return null;
		}

		[Obsolete("This method is obsolete. Please use FindElements(By @by) instead.", error: true)]
		public virtual IEnumerable<IWebElement> GetElements(By @by)
		{
			return null;
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
