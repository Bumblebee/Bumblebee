using System;
using System.Collections.Generic;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.Extensions
{
    public static class Miscellaneous
    {
        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> function)
        {
            foreach (var member in enumerable)
            {
                function(member);
            }
        }

        public static T While<T>(this T parent, Predicate<T> condition, Action<T> action)
        {
            while (condition(parent))
            {
                action(parent);
            }
            return parent;
        }
    }
}
