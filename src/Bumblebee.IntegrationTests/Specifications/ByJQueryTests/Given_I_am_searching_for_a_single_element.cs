using System;

using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using Bumblebee.Specifications;

using FluentAssertions;

using NUnit.Framework;

using OpenQA.Selenium;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Specifications.ByJQueryTests
{
	[TestFixture]
	public class Given_I_am_searching_for_a_single_element : HostTestFixture
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

		[TestCase("li", "Item 1")]
		[TestCase("li:eq(1)", "Item 2")]
		public void When_driver_is_used_Then_first_matching_element_on_page_is_returned(string selector, string expected)
		{
			var page = Threaded<Session>
				.CurrentBlock<PageWithJQuery>();

			var @by = new ByJQuery(selector);

			var actual = @by.FindElement(page.Session.Driver);

			actual.Text
				.Should().Be(expected);
		}

		[TestCase("li", "Item 5")]
		[TestCase("li:eq(1)", "Item 6")]
		public void When_element_is_used_Then_first_matching_element_in_scope_is_returned(string selector, string expected)
		{
			var page = Threaded<Session>
				.CurrentBlock<PageWithJQuery>();

			var @by = new ByJQuery(selector);

			var actual = @by.FindElement(page.ListB.Tag);

			actual.Text
				.Should().Be(expected);
		}

		[TestCase("li:eq(8)")]
		[TestCase("li:eq(100)")]
		public void When_driver_is_used_and_specification_selects_no_elements_Then_exception_is_thrown(string selector)
		{
			var page = Threaded<Session>
				.CurrentBlock<PageWithJQuery>();

			var @by = new ByJQuery(selector);

			Action fn = () => @by.FindElement(page.Session.Driver);

			fn.ShouldThrow<NotFoundException>();
		}

		[TestCase("li:eq(5)")]
		[TestCase("li:eq(100)")]
		public void When_element_is_used_and_specification_selects_no_elements_Then_exception_is_thrown(string selector)
		{
			var page = Threaded<Session>
				.CurrentBlock<PageWithJQuery>();

			var @by = new ByJQuery(selector);

			Action fn = () => @by.FindElement(page.ListB.Tag);

			fn.ShouldThrow<NotFoundException>();
		}

		[TestCase("li:eq(0)", "Item 1")]
		[TestCase("li:eq(1)", "Item 2")]
		[TestCase("li:eq(5)", "Item 6")]
		public void When_driver_is_used_and_specification_selects_single_element_Then_element_is_found(string selector, string text)
		{
			var page = Threaded<Session>
				.CurrentBlock<PageWithJQuery>();

			var @by = new ByJQuery(selector);

			var actual = @by.FindElement(page.Session.Driver);

			actual.Text
				.Should()
				.Be(text);
		}

		[TestCase("li:eq(0)", "Item 1")]
		[TestCase("li:eq(3)", "Item 4")]
		public void When_element_is_used_and_specification_selects_single_element_Then_element_is_found(string selector, string text)
		{
			var page = Threaded<Session>
				.CurrentBlock<PageWithJQuery>();

			var @by = new ByJQuery(selector);

			var actual = @by.FindElement(page.ListA.Tag);

			actual.Text
				.Should()
				.Be(text);
		}
	}
}
