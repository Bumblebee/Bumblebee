namespace Bumblebee.Interfaces
{
	public interface IAlertDialog : IBlock
	{
		TResult Accept<TResult>() where TResult : IBlock;
		TResult Dismiss<TResult>() where TResult : IBlock;
		IAlertDialog EnterText(string text);
		string Text { get; }
	}
}
