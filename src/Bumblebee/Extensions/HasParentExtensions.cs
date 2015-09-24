using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
	public static class HasParentExtensions
	{
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
