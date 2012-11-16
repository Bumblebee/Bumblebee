namespace Bumblebee.UI.Conditional
{
    public interface IConditionalClickable : IUIElement
    {
        TResult Click<TResult>() where TResult : Block;
        string Text { get; }
    }
}
