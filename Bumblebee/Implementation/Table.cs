using System;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class Table<T> : Element, ITable<T>
        where T : Element
    {
        private static readonly Type RowType = typeof (T);

        private static T Create(IBlock parent, By @by)
        {
            return (T) Activator.CreateInstance(RowType, parent, @by);
        }

        private static T Create(IBlock parent, IWebElement tag)
        {
            return (T) Activator.CreateInstance(RowType, parent, tag);
        }

        public Table(IBlock parent, By @by) : base(parent, @by)
        {
        }

        public Table(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }

        public IEnumerable<string> Columns
        {
            get
            {
                return GetElement(By.TagName("thead"))
                    .FindElement(By.TagName("tr"))
                    .FindElements(By.TagName("th"))
                    .Select(x => x.Text);
            }
        }

        public IEnumerable<T> Rows
        {
            get
            {
                return GetElement(By.TagName("tbody"))
                    .FindElements(By.TagName("tr"))
                    .Select(x => Create(this, x));
            }
        }

        public T Footer
        {
            get
            {
                var element = GetElement(By.TagName("tfoot"))
                    .FindElement(By.TagName("tr"));

                return Create(this, element);
            }
        }
    }

    public class Table : Element, ITable
    {
        public Table(IBlock parent, By @by) : base(parent, @by)
        {
        }

        public Table(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }

        public IEnumerable<string> Columns
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
                return GetElement(By.TagName("tbody"))
                    .FindElements(By.TagName("tr"))
                    .Select(x => new TableRow(this, x));
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
    }
}
