using System.Collections.Generic;

using Bumblebee.Implementation;

namespace Bumblebee.Interfaces
{
    public interface ITable<out T>
        where T : Element
    {
        IEnumerable<string> Columns { get; }
        IEnumerable<T> Rows { get; }
        T Footer { get; }
    }

    public interface ITable
    {
        IEnumerable<string> Columns { get; }
        IEnumerable<ITableRow> Rows { get; }
        IEnumerable<string> Footers { get; }
    }
}
