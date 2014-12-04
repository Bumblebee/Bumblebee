using System.Linq;
using Bumblebee.Extensions;
using Bumblebee.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Extensions
{
    public class FilteringTests
    {
        [TestCase("John", 1)]
        [TestCase("Todd", 2)]
        [TestCase("Patrick", 1)]
        public void given_a_list_of_items_with_text_when_getting_items_with_text_should_be_1(string text, int expectedCount)
        {
            var items = new[] {new ItemWithText("Todd"), new ItemWithText("John"), new ItemWithText("Patrick"), new ItemWithText("Todd"), };
            items
                .WithText(text)
                .Count().Should().Be(expectedCount);
        }
    }

    class ItemWithText : IHasText
    {
        public ItemWithText(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
