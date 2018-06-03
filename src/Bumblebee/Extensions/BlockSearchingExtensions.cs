using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
	public static class BlockSearchingExtensions
	{
		private static readonly Type BlockType = typeof (IBlock);
		private static readonly Type PageType = typeof (IPage);

		public static T FindRelated<T>(this IElement element) where T : IBlock
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

			return FindRelated<T>(element.Parent);
		}

		public static TBlock FindRelated<TBlock>(this IBlock block) where TBlock : IBlock
		{
			if (block == null)
			{
				throw new ArgumentNullException("block");
			}

			var ancestor = block;
			var type = typeof (TBlock);

			IDictionary<Type, bool> typesAlreadySearched = new Dictionary<Type, bool>();

			if (type.IsInstanceOfType(ancestor) == false)
			{
				if (PageType.IsAssignableFrom(type))
				{
					ancestor = Block.Create<TBlock>(block.Session);
				}
				else
				{
					while ((ancestor != null) && (type.IsInstanceOfType(ancestor) == false))
					{
						TBlock result;
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
						ancestor = Block.Create<TBlock>(block.Session);
					}
				}
			}

			return (TBlock) ancestor;
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

				var properties = GetBlockProperties(currentType);

				foreach (var property in properties)
				{
					if (typesAlreadySearched.ContainsKey(property.PropertyType) == false)
					{
						var child = property.GetValue(current);

						if (SearchDescendantsFor(ref typesAlreadySearched, child, out result))
						{
							success = true;

							break;
						}
					}
				}
			}

			return success;
		}

		private static IEnumerable<PropertyInfo> GetBlockProperties(Type current)
		{
			var unsearchedProperties = current
				.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
				.Where(x => BlockType.IsAssignableFrom(x.PropertyType));

			return unsearchedProperties;
		}
	}
}
