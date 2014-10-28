using System;

namespace Bumblebee.Interfaces
{
    public interface IDateField : IElement, IHasText
    {
        TCustomResult EnterDate<TCustomResult>(DateTime date) where TCustomResult : IBlock;

        DateTime? Value { get; }
    }

    public interface IDateField<out TResult> : IDateField where TResult : IBlock
    {
        TResult EnterDate(DateTime date);
    }
}