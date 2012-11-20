namespace Bumblebee.UI.Generic
{
   public interface IOption<out TResult> : IClickable<TResult>, ISelectable where TResult : Block
   {
   }
}
