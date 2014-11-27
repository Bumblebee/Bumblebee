namespace Bumblebee.Interfaces
{
    public interface INumericField : ITextField
    {
        TCustomResult EnterNumber<TCustomResult>(double number) where TCustomResult : IBlock;

        double? Value { get; }
    }

    public interface INumericField<out TResult> : INumericField, ITextField<TResult> where TResult : IBlock
    {
        TResult EnterNumber(double number);
    }
}