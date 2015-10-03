using System;
using System.Linq;

using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using Bumblebee.Specifications;

using FluentAssertions;

using NUnit.Framework;

using OpenQA.Selenium;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Specifications
{
	[TestFixture]
	public class ByOrdinalTests : HostTestFixture
	{
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			Threaded<Session>
				.With<Chrome>()
				.NavigateTo<ByOrdinalPage>(GetUrl("ByOrdinal.html"));
		}

		[TestFixtureTearDown]
		public void TestFixtureTearDown()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void When_null_by_is_provided_Then_exception_is_thrown()
		{
			Action fn = () => new ByOrdinal(null, 100);

			fn.ShouldThrow<ArgumentNullException>();
		}

		[Test]
		public void When_negative_ordinal_is_provided_Then_exception_is_thrown()
		{
			Action fn = () => new ByOrdinal(By.TagName("li"), -1);

			fn.ShouldThrow<ArgumentOutOfRangeException>();
		}

		[TestCase(8)]
		[TestCase(100)]
		public void When_ordinal_that_is_not_present_is_searched_for_Then_exception_is_thrown(int ordinal)
		{
			var page = Threaded<Session>
				.CurrentBlock<ByOrdinalPage>();

			var @by = new ByOrdinal(By.TagName("li"), ordinal);

			Action fn = () => @by.FindElement(page.Tag);

			fn.ShouldThrow<NotFoundException>();
		}

		[Test]
		public void When_ordinal_that_is_not_present_is_searched_for_Then_empty_collection_is_returned()
		{
			var page = Threaded<Session>
				.CurrentBlock<ByOrdinalPage>();

			var @by = new ByOrdinal(By.TagName("li"), 100);

			@by.FindElements(page.Tag)
				.Should()
				.BeEmpty();
		}

		[TestCase(0, "Item 1")]
		[TestCase(1, "Item 2")]
		[TestCase(5, "Item 6")]
		public void When_single_element_is_searched_for_Then_element_is_found(int ordinal, string text)
		{
			var page = Threaded<Session>
				.CurrentBlock<ByOrdinalPage>();

			var @by = new ByOrdinal(By.TagName("li"), ordinal);

			var actual = @by.FindElement(page.Tag);

			actual.Text
				.Should()
				.Be(text);
		}

		[TestCase(0, "Item 1")]
		[TestCase(1, "Item 2")]
		[TestCase(5, "Item 6")]
		public void When_element_collection_is_searched_for_Then_collection_with_single_element_is_found(int ordinal, string text)
		{
			var page = Threaded<Session>
				.CurrentBlock<ByOrdinalPage>();

			var @by = new ByOrdinal(By.TagName("li"), ordinal);

			var actual = @by.FindElements(page.Tag);

			actual
				.Select(x => x.Text)
				.Should().HaveCount(1)
				.And.HaveElementAt(0, text);
		}
	}
}
