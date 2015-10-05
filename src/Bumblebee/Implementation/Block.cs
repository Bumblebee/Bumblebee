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

		/// <summary>
		/// Allows for the creation of a derived Block based on a Session using reflection.
		/// </summary>
		/// <remarks>
		/// This method is used by the Session.CurrentBlock() method.
		/// </remarks>
		/// <param name="session"></param>
		/// <typeparam name="TBlock"></typeparam>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		internal static TBlock Create<TBlock>(Session session) where TBlock : IBlock
		{
			if (session == null)
			{
				throw new ArgumentNullException("session");
			}

			var type = typeof(TBlock);
			var ctor = type.GetConstructor(new[] { typeof(Session) });

			if (ctor == null)
			{
				throw new ArgumentException(String.Format("The specified type ({0}) is not a valid block or page. It must have a constructor that takes only a session.", type));
			}

			var result = (TBlock)ctor.Invoke(new object[] { session });

			return result;
		}

		/// <summary>
		/// Allows for the creation of a derived Block based on a parent Block and By specification using reflection.
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="by"></param>
		/// <typeparam name="TBlock"></typeparam>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public static TBlock Create<TBlock>(IBlock parent, By @by) where TBlock : IBlock
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}

			if (@by == null)
			{
				throw new ArgumentNullException("by");
			}

			var type = typeof(TBlock);
			var ctor = type.GetConstructor(new[] { typeof(IBlock), typeof(By) });

			if (ctor == null)
			{
				throw new ArgumentException(String.Format("The specified type ({0}) is not a valid block. It must have a constructor that takes an IBlock parent and a By specification.", type));
			}

			var result = (TBlock)ctor.Invoke(new object[] { parent, @by });

			return result;
		}

		private Block(Session session)
		{
			if (session != null)
			{
				session.SetCurrentBlock(this);
			}
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

		protected virtual IEnumerable<T> FindBlocks<T>(By @by) where T : IBlock
		{
			return new Blocks<T>(this, @by);
		}

		protected virtual IEnumerable<T> FindElements<T>(By @by) where T : IElement
		{
			return new Elements<T>(this, @by);
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
