using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
    static internal class Table
    {
        public static IEnumerable<T> CreateInstances<T>(this ITable table)
        {
            return table
                .Rows
                .Select(x => CreateInstance<T>(table, x));
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

        private static T CreateInstance<T>(ITable table, IEnumerable<string> tableRow)
        {
            var type = typeof (T);

            // we do this because the setters are not present on PropertyInfo objects acquired from inherited properties
            var properties = GetInheritanceChain(type)
                .SelectMany(x => x.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                .ToDictionary(k => k.Name, v => v, StringComparer.OrdinalIgnoreCase);

            var cells = table.Columns
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
    }
}
