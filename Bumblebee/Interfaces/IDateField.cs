using System;

namespace Bumblebee.Interfaces
{
    public interface IDateField : ITextField
    {
        TCustomResult EnterDate<TCustomResult>(DateTime date) where TCustomResult : IBlock;

        DateTime? Value { get; }
    }

    public interface IDateField<out TResult> : IDateField, ITextField<TResult> where TResult : IBlock
    {
        TResult EnterDate(DateTime date);
    }
}