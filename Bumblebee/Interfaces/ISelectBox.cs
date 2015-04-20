using System.Collections.Generic;

namespace Bumblebee.Interfaces
{
	public interface ISelectBox : IBlock
	{
		IEnumerable<IOption> Options { get; }
	}

	public interface ISelectBox<out TResult> : ISelectBox
		where TResult : IBlock
	{
		IEnumerable<IOption<TResult>> Options { get; }
	}
}
