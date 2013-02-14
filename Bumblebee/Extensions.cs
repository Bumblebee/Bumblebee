using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bumblebee.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;

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

        private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source, Random rng)
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
        public static T Verify<T>(this T obj, string verification, Predicate<T> predicate)
        {
            if (!predicate.Invoke(obj))
                throw new VerificationException(verification);

            return obj;
        }

        public static T Verify<T>(this T obj, Predicate<T> predicate)
        {
            return obj.Verify(null, predicate);
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
            return block.VerifyPresenceOf("element", by);
        }

        public static TBlock VerifyAbsence<TBlock>(this TBlock block, By by) where TBlock : IBlock
        {
            return block.VerifyAbsenceOf("element", by);
        }

        public static TBlock VerifyPresenceOf<TBlock>(this TBlock block, string element, By by) where TBlock : IBlock
        {
            if (!block.Tag.GetElements(by).Any())
                throw new VerificationException("Couldn't verify presence of " + element + " " + by);

            return block;
        }

        public static TBlock VerifyAbsenceOf<TBlock>(this TBlock block, string element, By by) where TBlock : IBlock
        {
            if (block.Tag.GetElements(by).Any())
                throw new VerificationException("Couldn't verify absence of " + element + " " + by);

            return block;
        }

        public static TBlock Store<TBlock, TData>(this TBlock block, out TData data, Func<TBlock, TData> exp)
        {
            data = exp.Invoke(block);
            return block;
        }
    }

    public static class AdvancedSeleniumActions
    {
        public static TElement Hover<TElement>(this TElement element, int pauseSeconds = 0) where TElement : IElement
        {
            new Actions(element.Session.Driver).MoveToElement(element.Tag).Perform();

            return element.Pause(pauseSeconds);
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
            if (seconds > 0) Thread.Sleep(1000 * seconds);

            return block;
        }
    }

    public static class WebElementConvenience
    {
        public static IWebDriver GetDriver(this IWebElement element)
        {
            return ((IWrapsDriver) element).WrappedDriver;
        }

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

        public static T ExecuteScript<T>(this IWebDriver driver, string script, params object[] args)
        {
            return (T)((IJavaScriptExecutor) driver).ExecuteScript(script, args);
        }

        public static IWebElement GetElementByJQuery(this IWebDriver driver, string query)
        {
            return driver.ExecuteScript<IWebElement>(string.Format("return $('{0}').get();", query));
        }

        public static T ExecuteFunction<T>(this IWebElement element, string function, params object[] args)
        {
            return element.GetDriver().ExecuteScript<T>("arguments[0]." + function, element, args);
        }

        public static T ExecuteJQueryFunction<T>(this IWebElement element, string function, params object[] args)
        {
            return element.GetDriver().ExecuteScript<T>("$(arguments[0])." + function, element, args);
        }

        public static void SetAttribute(this IWebElement element, string attribute, string value)
        {
            element.GetDriver().ExecuteScript<object>("arguments[0].setAttribute(arguments[1], arguments[2])", element, attribute, value);
        }
    }
}
