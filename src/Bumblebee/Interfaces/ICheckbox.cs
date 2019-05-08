namespace Bumblebee.Interfaces
{
	public interface ICheckbox : IElement, ISelectable
	{
		TResult Check<TResult>() where TResult : IBlock;
		TResult Uncheck<TResult>() where TResult : IBlock;
		TResult Toggle<TResult>() where TResult : IBlock;
	}

	public interface ICheckbox<out TResult> : ICheckbox
		where TResult : IBlock
	{
		TResult Check();
		TResult Uncheck();
		TResult Toggle();
	}
}
