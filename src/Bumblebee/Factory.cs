using System;

using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee
{
	internal static class Factory
	{
		public static T CreateBlockFromSession<T>(Session session) where T : IBlock // TODO: should probably create a page abstraction and use it here...
		{
			if (session == null)
			{
				throw new ArgumentNullException("session");
			}

			var type = typeof (T);
			var ctor = type.GetConstructor(new[] { typeof (Session) });

			if (ctor == null)
			{
				throw new ArgumentException(String.Format("The specified type ({0}) is not a valid top-level block. It must have a constructor that takes only a session.", type));
			}

			var result = (T) ctor.Invoke(new object[] { session });

			return result;
		}

		public static T CreateBlockFromParentAndSpecification<T>(IBlock parent, By @by) where T : IBlock
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}

			if (@by == null)
			{
				throw new ArgumentNullException("by");
			}

			var type = typeof (T);
			var ctor = type.GetConstructor(new[] { typeof (IBlock), typeof (By) });

			if (ctor == null)
			{
				throw new ArgumentException(String.Format("The specified type ({0}) is not a valid block. It must have a constructor that takes an IBlock parent and a By specification.", type));
			}

			var result = (T) ctor.Invoke(new object[] { parent, @by });

			return result;
		}

		public static T CreateElementFromParentAndSpecification<T>(IBlock parent, By @by) where T : IElement
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}

			if (@by == null)
			{
				throw new ArgumentNullException("by");
			}

			var type = typeof (T);
			var ctor = type.GetConstructor(new[] { typeof (IBlock), typeof (By) });

			if (ctor == null)
			{
				throw new ArgumentException(String.Format("The specified type ({0}) is not a valid block. It must have a constructor that takes an IBlock parent and a By specification.", type));
			}

			var result = (T) ctor.Invoke(new object[] { parent, @by });

			return result;
		}

		public static T CreateElementFromParentAndElement<T>(IBlock parent, IWebElement element) where T : IElement
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}

			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

			var type = typeof (T);
			var ctor = type.GetConstructor(new[] { typeof (IBlock), typeof (IWebElement) });

			if (ctor == null)
			{
				throw new ArgumentException(String.Format("The specified type ({0}) is not a valid block. It must have a constructor that takes an IBlock parent and a IWebElement backing element.", type));
			}

			var result = (T) ctor.Invoke(new object[] { parent, element });

			return result;
		}
	}
}
