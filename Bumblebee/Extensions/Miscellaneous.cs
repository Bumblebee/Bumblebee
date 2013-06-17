using System;
using System.Collections.Generic;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;

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

        public static TResult ForceClick<TResult>(this IClickable element) where TResult : IBlock
        {
            element.Tag.ExecuteJQueryFunction<bool?>("trigger('click')");
            return element.Session.CurrentBlock<TResult>(((Clickable)element).ParentBlock.Tag);
        }

        public static TResult ForceClick<TResult>(this IClickable<TResult> element) where TResult : IBlock
        {
            return ((IClickable) element).ForceClick<TResult>();
        }
    }
}
