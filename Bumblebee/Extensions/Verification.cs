using System;
using System.Collections.Generic;
using System.Linq;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Extensions
{
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

        public static TElement VerifyClasses<TElement>(this TElement block, IEnumerable<string> expectedClasses) where TElement : IElement
        {
            var classes = block.Tag.GetClasses();

            var missingClasses = expectedClasses.Where(expected => !classes.Contains(expected)).ToList();

            if (missingClasses.Any())
            {
                var message = "Block is missing the following expected classes: ";
                message += missingClasses.Aggregate((current, missingClass) => current + ", " + missingClass);
                throw new VerificationException(message);
            }

            return block;
        }

        public static TElement VerifyClasses<TElement>(this TElement block, params string[] expectedClasses) where TElement : IElement
        {
            return block.VerifyClasses((IEnumerable<string>) expectedClasses);
        }

        public static TBlock Store<TBlock, TData>(this TBlock block, out TData data, Func<TBlock, TData> exp)
        {
            data = exp.Invoke(block);
            return block;
        }
    }
}