using System;
using System.Collections.Generic;
using System.Linq;
using Bumblebee.UI;
using Bumblebee.UI.Generic;
using OpenQA.Selenium;

namespace Bumblebee
{
    public static class Extensions
    {
        public static IEnumerable<TResult> WithText<TResult>(this IEnumerable<TResult> haveText, string text) where TResult : IHasText
        {
            return haveText.Where(clickable => clickable.Text == text);
        }
        
        public static IEnumerable<TSelectable> Unselected<TSelectable>(this IEnumerable<TSelectable> options) where TSelectable : ISelectable
        {
            return options.Where(option => !option.Selected);
        }

        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.OrderBy(id => new Guid()).First();
        }

        public static string GetID(this IWebElement element)
        {
            return element.GetAttribute("id");
        }
    }
}
