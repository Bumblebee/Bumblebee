using System;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Table : Block, ITable
	{
		protected static T Create<T>(IBlock parent, By @by)
		{
			return (T) Activator.CreateInstance(typeof (T), parent, @by);
		}

		protected static T Create<T>(IBlock parent, IWebElement tag)
		{
			return (T) Activator.CreateInstance(typeof (T), parent, tag);
		}

		public Table(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public IEnumerable<string> Headers
		{
			get
			{
				return GetElement(By.TagName("thead"))
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
				return GetElement(By.TagName("tfoot"))
					.FindElement(By.TagName("tr"))
					.FindElements(By.TagName("td"))
					.Select(x => x.Text);
			}
		}

		public T HeaderAs<T>()
			where T : IBlock
		{
			return Create<T>(this, By.TagName("thead"));
		}

		public IEnumerable<T> RowsAs<T>()
			where T : IBlock
		{
			return new BlockEnumerable<T>(this, By.CssSelector("tbody > tr"));
		}

		public T FooterAs<T>()
			where T : IBlock
		{
			return Create<T>(this, By.TagName("tfoot"));
		}
	}
}
