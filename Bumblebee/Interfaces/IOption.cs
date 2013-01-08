namespace Bumblebee.Interfaces
{
    public interface IOption : IClickable, ISelectable
    {
    }

   public interface IOption<out TResult> : IClickable<TResult>, ISelectable where TResult : IBlock
   {
   }
}
