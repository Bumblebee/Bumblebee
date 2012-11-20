namespace Bumblebee.UI.Generic
{
    public interface IClickable<out TResult> : IUIElement, IHasText where TResult : Block
    {
        TResult Click();
    }
}
