using System.Collections.Generic;

namespace Bumblebee.Interfaces
{
	public interface ISelectBox : IElement
	{
		IEnumerable<IOption> Options { get; }
	}

	public interface ISelectBox<out TResult> : IGenericElement<TResult>
		where TResult : IBlock
	{
		IEnumerable<IOption<TResult>> Options { get; }
	}
}
