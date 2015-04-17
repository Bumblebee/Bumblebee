using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public abstract class Block : IBlock
	{
		private static readonly Type BlockType = typeof (IBlock);

		public IBlock ParentBlock { get; private set; }
		public Session Session { get; private set; }
		public By Specification { get; private set; }

		public virtual IWebElement Tag
		{
			get
			{
				ISearchContext context = Session.Driver;

				if (ParentBlock != null)
				{
					context = ParentBlock.Tag;
				}

				return context.FindElement(Specification);
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
			ParentBlock = parent;

			if (Session.Monkey != null)
			{
				Session.Monkey.Invoke(this);
			}
		}

		protected IList<IWebElement> FindElements(By @by)
		{
			return Tag.FindElements(@by);
		}

		[Obsolete("This method is obsolete. Please use FindElements instead.")]
		protected IList<IWebElement> GetElements(By @by)
		{
			return FindElements(@by);
		}

		protected IWebElement FindElement(By @by)
		{
			return Tag.FindElement(@by);
		}

		[Obsolete("This method is obsolete. Please use FindElement instead.")]
		protected IWebElement GetElement(By @by)
		{
			return FindElement(@by);
		}

		protected T FindRelated<T>() where T : IBlock
		{
			IList<Type> typesAlreadySearched = new List<Type>();

			IBlock ancestor = this;

			var type = typeof (T);

			if (type != GetType())
			{
				var session = Session;

				while ((ancestor != null) && (type.IsInstanceOfType(ancestor) == false))
				{
					T result;
					if (SearchDescendantsFor(ref typesAlreadySearched, ancestor, out result))
					{
						ancestor = result;
					}
					else
					{
						ancestor = ancestor.ParentBlock;
					}
				}

				if (ancestor == null)
				{
					ancestor = Factory.CreateBlockFromSession<T>(session);
				}
			}

			return (T) ancestor;
		}

		private static bool SearchDescendantsFor<T>(ref IList<Type> typesAlreadySearched, object current, out T result)
		{
			var success = false;

			result = default (T);

			if (typeof (T).IsInstanceOfType(current))
			{
				result = (T) current;

				success = true;
			}
			else
			{
				var currentType = current.GetType();

				typesAlreadySearched.Add(currentType);

				var properties = GetBlockPropertiesThatHaveNotBeenSearched(currentType, typesAlreadySearched);

				foreach (var property in properties)
				{
					var child = property.GetValue(current);

					if (SearchDescendantsFor(ref typesAlreadySearched, child, out result))
					{
						success = true;

						break;
					}
				}
			}

			return success;
		}

		private static IEnumerable<PropertyInfo> GetBlockPropertiesThatHaveNotBeenSearched(Type current, ICollection<Type> typesAlreadySearched)
		{
			var unsearchedProperties = current
				.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
				.Where(x => BlockType.IsAssignableFrom(x.PropertyType))
				.Where(x => typesAlreadySearched.Contains(x.PropertyType) == false);

			return unsearchedProperties;
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
