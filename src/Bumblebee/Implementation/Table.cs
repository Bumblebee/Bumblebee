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
				return new BlockEnumerable<TableRow>(this, By.CssSelector("tbody > tr"));
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

		public T HeaderAs<T>()
			where T : IBlock
		{
			return Factory.CreateBlockFromParentAndSpecification<T>(this, By.TagName("thead"));
		}

		public IEnumerable<T> RowsAs<T>()
			where T : IBlock
		{
			return new BlockEnumerable<T>(this, By.CssSelector("tbody > tr"));
		}

		public T FooterAs<T>()
			where T : IBlock
		{
			return Factory.CreateBlockFromParentAndSpecification<T>(this, By.TagName("tfoot"));
		}
	}
}
