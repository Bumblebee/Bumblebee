using System.Collections.Generic;

using Bumblebee.Implementation;

namespace Bumblebee.Interfaces
{
    public interface ITable
    {
        IEnumerable<string> Headers { get; }
        IEnumerable<ITableRow> Rows { get; }
        IEnumerable<string> Footers { get; }
        T HeaderAs<T>() where T : SpecificBlock;
        IEnumerable<T> RowsAs<T>() where T : SpecificBlock;
        T FooterAs<T>() where T : SpecificBlock;
    }
}
