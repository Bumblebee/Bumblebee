using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class TableRow : Element, ITableRow
	{
		private readonly IDictionary<string, string> _data;

		public string this[int index]
		{
			get { return _data.Values.ElementAt(index); }
		}

		public string this[string column]
		{
			get { return _data[column]; }
		}

		public TableRow(IBlock parent, By @by) : base(parent, @by)
		{
			_data = ParentBlock.Tag
				.FindElement(By.TagName("thead"))
				.FindElement(By.TagName("tr"))
				.FindElements(By.TagName("th"))
				.Zip(FindElements(By.TagName("td")), (header, cell) => new KeyValuePair<string, string>(header.Text, cell.Text))
				.ToDictionary(x => x.Key, x => x.Value);
		}

		public TableRow(IBlock parent, IWebElement tag) : base(parent, tag)
		{
			_data = ParentBlock.Tag
				.FindElement(By.TagName("thead"))
				.FindElement(By.TagName("tr"))
				.FindElements(By.TagName("th"))
				.Zip(FindElements(By.TagName("td")), (header, cell) => new KeyValuePair<string, string>(header.Text, cell.Text))
				.ToDictionary(x => x.Key, x => x.Value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<string> GetEnumerator()
		{
			return _data.Values.GetEnumerator();
		}
	}
}
