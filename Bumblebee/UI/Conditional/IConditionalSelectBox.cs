namespace Bumblebee.UI.Conditional
{
    public interface IConditionalSelectBox : IUIElement
    {
        TResult Select<TResult>(int index) where TResult : Block;
        TResult Select<TResult>(string text) where TResult : Block;
    }
}