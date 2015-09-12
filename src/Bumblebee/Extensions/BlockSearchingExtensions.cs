using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
	public static class BlockSearchingExtensions
	{
		private static readonly Type BlockType = typeof (IBlock);

		public static T FindRelated<T>(this IElement element) where T : IBlock
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

			return FindRelated<T>(element.Parent);
		}

		public static T FindRelated<T>(this IBlock block) where T : IBlock
		{
			if (block == null)
			{
				throw new ArgumentNullException("block");
			}

			var ancestor = block;
			var type = typeof (T);

			IDictionary<Type, bool> typesAlreadySearched = new Dictionary<Type, bool>();

			while ((ancestor != null) && (type.IsInstanceOfType(ancestor) == false))
			{
				T result;
				if (SearchDescendantsFor(ref typesAlreadySearched, ancestor, out result))
				{
					ancestor = result;
				}
				else
				{
					ancestor = ancestor.Parent;
				}
			}

			if (ancestor == null)
			{
				ancestor = Factory.CreateBlockFromSession<T>(block.Session);
			}

			return (T) ancestor;
		}

		private static bool SearchDescendantsFor<T>(ref IDictionary<Type, bool> typesAlreadySearched, object current, out T result)
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

				typesAlreadySearched[currentType] = true;

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

		private static IEnumerable<PropertyInfo> GetBlockPropertiesThatHaveNotBeenSearched(Type current, IDictionary<Type, bool> typesAlreadySearched)
		{
			var unsearchedProperties = current
				.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
				.Where(x => BlockType.IsAssignableFrom(x.PropertyType))
				.Where(x => typesAlreadySearched.ContainsKey(x.PropertyType) == false);

			return unsearchedProperties;
		}
	}
}
