using System;

using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
	public static class BlockConvenience
	{
		[Obsolete("This method should no longer be used. Please use FindRelated<T> instead.")]
		public static TScope ScopeTo<TScope>(this IBlock block)
			where TScope : IBlock
		{
			return block.Session.CurrentBlock<TScope>();
		}
	}
}
