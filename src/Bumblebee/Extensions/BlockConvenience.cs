using System;

using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
	public static class BlockConvenience
	{
		// TODO:  Should this be marked as error now?
		[Obsolete("This method should no longer be used. Please use FindRelated<T> instead.", error: true)]
		public static TScope ScopeTo<TScope>(this IBlock block)
			where TScope : IBlock
		{
			return block.Session.CurrentBlock<TScope>();
		}
	}
}
