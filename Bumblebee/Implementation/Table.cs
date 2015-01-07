using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class Table<T> : Table, ITable<T>
        where T : Element
    {
        public Table(IBlock parent, By @by) : base(parent, @by)
        {
        }

        public Table(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }

        public new IEnumerable<T> Rows
        {
            get
            {
                return GetElement(By.TagName("tbody"))
                    .FindElements(By.TagName("tr"))
                    .Select(x => Create<T>(this, x));
            }
        }
    }

    public class Table : Element, ITable
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

        public T GetHeader<T>()
            where T : Element
        {
            return Create<T>(this, By.TagName("thead"));
        }

        public IEnumerable<T> GetRows<T>()
        {
            return Rows
                .Select(CreateInstance<T>);
        }

        private static IEnumerable<Type> GetInheritanceChain(Type type)
        {
            var b = type;

            while (b != null)
            {
                yield return b;

                b = b.BaseType;
            }
        }

        private T CreateInstance<T>(IEnumerable<string> tableRow)
        {
            var type = typeof(T);

            // we do this because the setters are not present on PropertyInfo objects acquired from inherited properties
            var properties = GetInheritanceChain(type)
                .SelectMany(x => x.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                .ToDictionary(k => k.Name, v => v, StringComparer.OrdinalIgnoreCase);

            var cells = Columns
                .Select(x => Regex.Replace(x, @"\s+", String.Empty))
                .Zip(tableRow, (name, data) => new KeyValuePair<string, string>(name, data));

            var result = Activator.CreateInstance<T>();

            foreach (var cell in cells)
            {
                PropertyInfo property;
                if (properties.TryGetValue(cell.Key, out property))
                {
                    property.SetValue(result, Convert.ChangeType(cell.Value, property.PropertyType));
                }
            }

            return result;
        }

        public T GetFooter<T>()
            where T : Element
        {
            return Create<T>(this, By.TagName("tfoot"));
        }
    }
}
