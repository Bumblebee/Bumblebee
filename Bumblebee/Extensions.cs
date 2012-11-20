using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public static TBlock Pause<TBlock>(this TBlock block, int seconds) where TBlock : Block
        {
            Thread.Sleep(1000 * seconds);
            return block;
        }

        public static TBlock VerifyPresence<TBlock>(this TBlock block, By by) where TBlock : Block
        {
            block.VerifyElementPresent(by);
            return block;
        }

        public static TBlock VerifyAbsence<TBlock>(this TBlock block, By by) where TBlock : Block
        {
            block.VerifyElementAbsent(by);
            return block;
        }
    }
}
