using System.Collections.Generic;

using Bumblebee.Implementation;

namespace Bumblebee.Interfaces
{
	public interface ITable
	{
		IEnumerable<string> Headers { get; }
		IEnumerable<ITableRow> Rows { get; }
		IEnumerable<string> Footers { get; }
		T HeaderAs<T>() where T : Element;
		IEnumerable<T> RowsAs<T>() where T : Element;
		T FooterAs<T>() where T : Element;
	}
}
