using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.UI;
using Bumblebee.UI.Generic;
using OpenQA.Selenium;

namespace Bumblebee
{
    public static class Extensions
    {
        public static IEnumerable<IClickable<TResult>> WithText<TResult>(this IEnumerable<IClickable<TResult>> clickables, string text) where TResult : Block
        {
            return clickables.Where(clickable => clickable.Text == text);
        }
        
        public static IEnumerable<IOption<TResult>> Unselected<TResult>(this IEnumerable<IOption<TResult>> options) where TResult : Block
        {
            return options.Where(option => !option.Selected);
        }

        public static string GetID(this IWebElement element)
        {
            return element.GetAttribute("id");
        }
    }
}
