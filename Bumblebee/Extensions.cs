using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee
{
    public static class Filtering
    {
        public static IEnumerable<TResult> WithText<TResult>(this IEnumerable<TResult> haveText, string text) where TResult : IHasText
        {
            return haveText.Where(hasText => hasText.Text.Trim() == text.Trim());
        }

        public static IEnumerable<TResult> ContainingText<TResult>(this IEnumerable<TResult> haveText, string text) where TResult : IHasText
        {
            return haveText.Where(hasText => hasText.Text.Contains(text.Trim()));
        }

        public static IEnumerable<TSelectable> Unselected<TSelectable>(this IEnumerable<TSelectable> options) where TSelectable : ISelectable
        {
            return options.Where(option => !option.Selected);
        }

        public static IEnumerable<TSelectable> Selected<TSelectable>(this IEnumerable<TSelectable> options) where TSelectable : ISelectable
        {
            return options.Where(option => option.Selected);
        }
    }

    public static class Randomization
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var rng = new Random();
            return source.Shuffle(rng);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (rng == null) throw new ArgumentNullException("rng");

            return source.ShuffleIterator(rng);
        }

        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();

            for (var i = 0; i < buffer.Count; i++)
            {
                var j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }

        public static T Random<T>(this IEnumerable<T> source)
        {
            var rng = new Random();
            return source.Random(rng);
        }

        public static T Random<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (rng == null) throw new ArgumentNullException("rng");

            return RandomIterator(source, rng);
        }

        private static T RandomIterator<T>(this IEnumerable<T> source, Random rng)
        {
            var buffer = source as IList<T> ?? source.ToList();
            return buffer[rng.Next(buffer.Count)];
        }
    }

    public static class Verification
    {
        public static T Verify<T>(this T obj, Predicate<T> assertion)
        {
            if (!assertion.Invoke(obj))
                throw new VerificationException("Verification failed on object " + obj);

            return obj;
        }

        public static TSelectable VerifySelected<TSelectable>(this TSelectable selectable, bool selected) where TSelectable : ISelectable
        {
            if (selectable.Selected != selected)
                throw new VerificationException("Selection verification failed. Expected: " + selected + ", Actual: " + selectable.Selected + ".");

            return selectable;
        }

        public static THasText VerifyText<THasText>(this THasText hasText, string text) where THasText : IHasText
        {
            if (hasText.Text != text)
                throw new VerificationException("Text verification failed. Expected: " + text + ", Actual: " + hasText.Text + ".");
            return hasText;
        }

        public static THasText VerifyTextMismatch<THasText>(this THasText hasText, string text) where THasText : IHasText
        {
            if (hasText.Text == text)
                throw new VerificationException("Text mismatch verification failed. Unexpected: " + text + ", Actual: " + hasText.Text + ".");
            return hasText;
        }

        public static THasText VerifyTextContains<THasText>(this THasText hasText, string text)
            where THasText : IHasText
        {
            if (!hasText.Text.Contains(text))
                throw new VerificationException("Expected \"" + hasText.Text + "\" to contain \"" + text + "\"");
            return hasText;
        }

        public static TBlock VerifyPresence<TBlock>(this TBlock block, By by) where TBlock : IBlock
        {
            if (!block.Tag.FindElements(by).Any())
                throw new VerificationException("Couldn't verify presence of element " + by);

            return block;
        }

        public static TBlock VerifyAbsence<TBlock>(this TBlock block, By by) where TBlock : IBlock
        {
            if (block.Tag.FindElements(by).Any())
                throw new VerificationException("Couldn't verify absence of element " + by);

            return block;
        }

        public static TBlock Store<TBlock, TData>(this TBlock block, out TData data, Func<TBlock, TData> exp)
        {
            data = exp.Invoke(block);
            return block;
        }

        public static TBlock VerifyEquality<TBlock>(this TBlock block, object expected, object actual)
        {
            if (!expected.Equals(actual))
                throw new VerificationException("Couldn't verify equality. Expected: " + expected + ". Actual: " + actual);

            return block;
        }

        public static TBlock VerifyInequality<TBlock>(this TBlock block, object unexpected, object actual)
        {
            if (unexpected.Equals(actual))
                throw new VerificationException("Couldn't verify inequality. Unxpected: " + unexpected + ". Actual: " + actual);

            return block;
        }
    }

    public static class Debugging
    {
        public static T DebugPrint<T>(this T obj)
        {
            Console.WriteLine(obj.ToString());
            return obj;
        }

        public static T DebugPrint<T>(this T obj, Func<T, object> func)
        {
            Console.WriteLine(func.Invoke(obj));
            return obj;
        }

        public static T Pause<T>(this T block, int seconds)
        {
            Thread.Sleep(1000 * seconds);
            return block;
        }

        public static T Pause<T>(this T block)
        {
            Console.ReadLine();
            return block;
        }
    }

    public static class WebElementConvenience
    {
        public static IList<IWebElement> GetElements(this IWebDriver driver, By by)
        {
            return driver.FindElements(by);
        }

        public static IWebElement GetElement(this IWebDriver driver, By by)
        {
            var elements = driver.GetElements(by);

            if (!elements.Any())
                throw new NoSuchElementException("Tried to get element with selector " + by);

            return elements.First();
        }

        public static IEnumerable<IWebElement> GetElements(this IWebElement element, By by)
        {
            return element.FindElements(by);
        }

        public static IWebElement GetElement(this IWebElement element, By by)
        {
            var elements = element.FindElements(by);

            if (!elements.Any())
                throw new NoSuchElementException("Tried to get element with selector " + by);

            return elements.First();
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
            return element.GetClasses().Any(@class => @class.Equals(className));
        }

        public static IWebElement GetElementByJQuery(this IWebDriver driver, string query)
        {
            return ((IJavaScriptExecutor) driver).ExecuteScript(string.Format("return $('{0}').get();", query)) as IWebElement;
        }
    }
}
