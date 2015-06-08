using System;
using System.Collections.Generic;

using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public abstract class Block : IBlock
	{
		public Session Session { get; private set; }

		public IWebElement Tag { get; protected set; }

		protected Block(Session session)
		{
			Session = session;

			if (Session.Monkey != null)
			{
				Session.Monkey.Invoke(this);
			}
		}

		public IList<IWebElement> FindElements(By by)
		{
			if (Tag == null)
			{
				throw new NullReferenceException("You can't call GetElements on a block without first initializing Tag.");
			}

			return Tag.FindElements(by);
		}

		[Obsolete("This method is obsolete. It will be removed in a future version. Please use FindElements() instead.")]
		public IList<IWebElement> GetElements(By by)
		{
			if (Tag == null)
			{
				throw new NullReferenceException("You can't call GetElements on a block without first initializing Tag.");
			}

			return Tag.FindElements(by);
		}

		public IWebElement FindElement(By by)
		{
			if (Tag == null)
			{
				throw new NullReferenceException("You can't call GetElement on a block without first initializing Tag.");
			}

			return Tag.FindElement(by);
		}

		[Obsolete("This method is obsolete. It will be removed in a future version. Please use FindElement() instead.")]
		public IWebElement GetElement(By by)
		{
			if (Tag == null)
			{
				throw new NullReferenceException("You can't call GetElement on a block without first initializing Tag.");
			}

			return Tag.FindElement(by);
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
