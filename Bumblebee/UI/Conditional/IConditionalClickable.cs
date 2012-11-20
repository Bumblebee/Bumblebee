namespace Bumblebee.UI.Conditional
{
    public interface IConditionalClickable : IUIElement, IHasText
    {
        TResult Click<TResult>() where TResult : Block;
    }
}
