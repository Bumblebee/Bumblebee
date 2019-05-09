namespace Bumblebee.Interfaces
{
	public interface IOption : IClickable, ISelectable, IFocusable
	{
	}

	public interface IOption<out TResult> : IOption, IClickable<TResult>, IFocusable<TResult>
		where TResult : IBlock
	{
	}
}