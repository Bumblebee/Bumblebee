using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
	/// <summary>
	/// Contains the static methods for retrieving a component's parent.
	/// </summary>
	public static class HasParentExtensions
	{
		/// <summary>
		/// Converts the parent block to type <typeparamref name="TParent" />, or it's default if the conversion isn't possible.
		/// </summary>
		/// <param name="hasParent">The element with the parent we want to convert.</param>
		/// <typeparam name="TParent">The type to convert the parent to.</typeparam>
		/// <returns>The parent block cast as the specified type, or the default of the specified type if the cast would throw an error.</returns>
		public static TParent ParentAs<TParent>(this IHasParent hasParent)
			where TParent : IBlock
		{
			var type = typeof (TParent);

			var result = default (TParent);

			if (type.IsInstanceOfType(hasParent.Parent))
			{
				result = (TParent) hasParent.Parent;
			}

			return result;
		}
	}
}
