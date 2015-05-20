using System;

namespace Bumblebee.Interfaces
{
	[Obsolete("There's no need to use this. Instead, verify from a parent block with a lambda.")]
	public interface IAllowsNoOp<out TResult> : IGenericElement<TResult>
		where TResult : IBlock
	{
	}
}
