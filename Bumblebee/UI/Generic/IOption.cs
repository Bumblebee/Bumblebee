namespace Bumblebee.UI.Generic
{
   public interface IOption<out TResult> : IClickable<TResult> where TResult : Block
   {
      bool Selected { get; }
   }
}
