namespace Bumblebee.Interfaces
{
    public interface INumericField : IElement, IHasText
    {
        TCustomResult EnterNumber<TCustomResult>(double number) where TCustomResult : IBlock;

        double? Value { get; }
    }

    public interface INumericField<out TResult> : INumericField where TResult : IBlock
    {
        TResult EnterNumber(double number);
    }
}