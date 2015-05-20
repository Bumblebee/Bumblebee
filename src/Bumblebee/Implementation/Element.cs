using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public abstract class Element : IElement
	{
		private static readonly Type BlockType = typeof (IBlock);

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

		protected T FindRelated<T>() where T : IBlock
		{
			IList<Type> typesAlreadySearched = new List<Type>();

			var type = typeof (T);

			var ancestor = ParentBlock;
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

		public IPerformsDragAndDrop GetDragAndDropPerformer()
		{
			return new WebDragAndDropPerformer(Session.Driver);
		}
	}
}
