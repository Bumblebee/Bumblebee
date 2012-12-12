using Bumblebee.Implementation;

namespace Bumblebee.Interfaces
{
    public interface IAlertDialog : IBlock
    {
        TResult Accept<TResult>() where TResult : IBlock;
        TResult Dismiss<TResult>() where TResult : IBlock;
        AlertDialog EnterText(string text);
        string Text { get; }
    }
}