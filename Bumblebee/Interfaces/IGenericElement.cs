using System;

namespace Bumblebee.Interfaces
{
	[Obsolete("This interface is useless and will be removed in a future release.")]
	public interface IGenericElement<out TResult> : IElement
		where TResult : IBlock
	{
	}
}
