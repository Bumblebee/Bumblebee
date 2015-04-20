namespace Bumblebee.Interfaces
{
	public interface IOption : IClickable, ISelectable
	{
	}

	public interface IOption<out TResult> : IOption, IClickable<TResult>
		where TResult : IBlock
	{
	}
}
