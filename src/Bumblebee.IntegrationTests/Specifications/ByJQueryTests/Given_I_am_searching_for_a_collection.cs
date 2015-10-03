using System.Linq;

using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using Bumblebee.Specifications;

using FluentAssertions;

using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Specifications.ByJQueryTests
{
	[TestFixture]
	public class Given_I_am_searching_for_a_collection : HostTestFixture
	{
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			Threaded<Session>
				.With<Chrome>()
				.NavigateTo<PageWithJQuery>(GetUrl("PageWithJQuery.html"));
		}

		[TestFixtureTearDown]
		public void TestFixtureTearDown()
		{
			Threaded<Session>
				.End();
		}

		[TestCase("li", 8)]
		[TestCase("li:eq(1)", 1)]
		[TestCase("span", 0)]
		public void When_driver_is_used_Then_all_elements_on_page_are_returned(string selector, int expected)
		{
			var page = Threaded<Session>
				.CurrentBlock<PageWithJQuery>();

			var @by = new ByJQuery(selector);

			@by.FindElements(page.Session.Driver)
				.Should()
				.HaveCount(expected);
		}

		[TestCase("li", 4)]
		[TestCase("li:eq(1)", 1)]
		[TestCase("ul", 0)]
		public void When_element_is_used_Then_contains_scoped_elements_are_returned(string selector, int expected)
		{
			var page = Threaded<Session>
				.CurrentBlock<PageWithJQuery>();

			var @by = new ByJQuery(selector);

			var actual = @by.FindElements(page.ListA.Tag);

			actual
				.Select(x => x.Text)
				.Should().HaveCount(expected);
		}

		[TestCase("li:eq(0)", "Item 1")]
		[TestCase("li:eq(1)", "Item 2")]
		[TestCase("li:eq(5)", "Item 6")]
		public void When_driver_is_used_and_specification_contains_single_element_Then_collection_containing_single_element_is_returned(string selector, string text)
		{
			var page = Threaded<Session>
				.CurrentBlock<PageWithJQuery>();

			var @by = new ByJQuery(selector);

			var actual = @by.FindElements(page.Session.Driver);

			actual
				.Select(x => x.Text)
				.Should().HaveCount(1)
				.And.HaveElementAt(0, text);
		}

		[TestCase("li:eq(0)", "Item 1")]
		[TestCase("li:eq(1)", "Item 2")]
		[TestCase("li:eq(2)", "Item 3")]
		[TestCase("li:eq(3)", "Item 4")]
		public void When_element_is_used_and_specification_contains_single_element_Then_collection_containing_single_element_is_returned(string selector, string text)
		{
			var page = Threaded<Session>
				.CurrentBlock<PageWithJQuery>();

			var @by = new ByJQuery(selector);

			var actual = @by.FindElements(page.ListA.Tag);

			actual
				.Select(x => x.Text)
				.Should().HaveCount(1)
				.And.HaveElementAt(0, text);
		}
	}
}
