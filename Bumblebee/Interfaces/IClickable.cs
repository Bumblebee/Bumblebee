namespace Bumblebee.Interfaces
{
	public interface IClickable : IElement, IHasText
	{
		TResult Click<TResult>() where TResult : IBlock;
	}

	public interface IClickable<out TResult> : IClickable, IGenericElement<TResult>
		where TResult : IBlock
	{
		TResult Click();
	}
}
