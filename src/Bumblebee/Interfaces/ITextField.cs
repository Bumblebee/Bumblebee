namespace Bumblebee.Interfaces
{
	public interface ITextField : IElement, IHasText
	{
		TResult Press<TResult>(Key key) where TResult : IBlock;
		TResult EnterText<TResult>(string text) where TResult : IBlock;
		TResult AppendText<TResult>(string text) where TResult : IBlock;
	}

	public interface ITextField<out TResult> : ITextField
		where TResult : IBlock
	{
		TResult Press(Key key);
		TResult EnterText(string text);
		TResult AppendText(string text);
	}
}
