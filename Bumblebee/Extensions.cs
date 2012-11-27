using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bumblebee.Interfaces;
using Ionic.Zip;
using OpenQA.Selenium;

namespace Bumblebee
{
    public static class Extensions
    {
        public static IEnumerable<TResult> WithText<TResult>(this IEnumerable<TResult> haveText, string text) where TResult : IHasText
        {
            return haveText.Where(hasText => hasText.Text == text);
        }

        public static TResult SingleWithText<TResult>(this IEnumerable<TResult> haveText, string text) where TResult : IHasText
        {
            return haveText.Single(hasText => hasText.Text == text);
        }
        
        public static IEnumerable<TSelectable> Unselected<TSelectable>(this IEnumerable<TSelectable> options) where TSelectable : ISelectable
        {
            return options.Where(option => !option.Selected);
        }

        public static TSelectable VerifySelected<TSelectable>(this TSelectable selectable, bool selected) where TSelectable : ISelectable
        {
            if (selectable.Selected != selected)
                throw new BadStateException("Selection verification failed. Expected: " + selected + ", Actual: " + selectable.Selected + ".");
            return selectable;
        }

        public static THasText VerifyText<THasText>(this THasText hasText, string text) where THasText : IHasText
        {
            if (hasText.Text != text)
                throw new BadStateException("Text verification failed. Expected: " + text + ", Actual: " + hasText.Text + ".");
            return hasText;
        }

        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.OrderBy(id => new Guid()).First();
        }

        public static string GetID(this IWebElement element)
        {
            return element.GetAttribute("id");
        }

        public static IEnumerable<string> GetClasses(this IWebElement element)
        {
            return element.GetAttribute("class").Split(' ');
        }

        public static bool HasClass(this IWebElement element, string className)
        {
            return element.GetClasses().Contains("className");
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
