using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Table : Block, ITable
	{
		public Table(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public IEnumerable<string> Headers
		{
			get
			{
				return FindElement(By.TagName("thead"))
					.FindElement(By.TagName("tr"))
					.FindElements(By.TagName("th"))
					.Select(x => x.Text);
			}
		}

		public IEnumerable<ITableRow> Rows
		{
			get
			{
				return FindBlocks<TableRow>(By.CssSelector("tbody > tr"));
			}
		}

		public IEnumerable<string> Footers
		{
			get
			{
				return FindElement(By.TagName("tfoot"))
					.FindElement(By.TagName("tr"))
					.FindElements(By.TagName("td"))
					.Select(x => x.Text);
			}
		}

		public TBlock HeaderAs<TBlock>()
			where TBlock : IBlock
		{
			return Block.Create<TBlock>(this, By.TagName("thead"));
		}

		public IEnumerable<T> RowsAs<T>()
			where T : IBlock
		{
			return FindBlocks<T>(By.CssSelector("tbody > tr"));
		}

		public TBlock FooterAs<TBlock>()
			where TBlock : IBlock
		{
			return Block.Create<TBlock>(this, By.TagName("tfoot"));
		}
	}
}
