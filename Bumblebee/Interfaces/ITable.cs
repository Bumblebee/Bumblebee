using System.Collections.Generic;

using Bumblebee.Implementation;

namespace Bumblebee.Interfaces
{
    public interface ITable<out T> : ITable
        where T : Element
    {
        IEnumerable<T> Rows { get; }
    }

    public interface ITable
    {
        IEnumerable<string> Columns { get; }
        IEnumerable<ITableRow> Rows { get; }
        IEnumerable<string> Footers { get; }
        T GetHeader<T>() where T : Element;
        IEnumerable<T> GetRows<T>();
        T GetFooter<T>() where T : Element;
    }
}
