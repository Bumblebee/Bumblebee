using System;

namespace Bumblebee.Interfaces
{
	[Obsolete("Make a string property instead that directly returns the text. Do verifications through a lambda on the parent block.")]
	public interface ICopy<out TResult> : IAllowsNoOp<TResult>, IHasText where TResult : IBlock
	{
	}
}
