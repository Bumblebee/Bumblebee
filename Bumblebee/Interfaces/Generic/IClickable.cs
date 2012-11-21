namespace Bumblebee.Interfaces.Generic
{
    public interface IClickable<out TResult> : IElement, IHasText where TResult : Block
    {
        TResult Click();
    }
}
