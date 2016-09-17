using System;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

using OpenQA.Selenium;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Specifications.ByJQueryTests
{
	[TestFixture]
	public class Given_page_loads_slowly : HostTestFixture
	{
		[OneTimeSetUp]
		public void TestFixtureSetUp()
		{
			Threaded<Session>
				.With<Chrome>()
				.NavigateTo<SlowPageWithJQuery>(GetUrl("SlowPageWithJQuery.html"));
		}

		[OneTimeTearDown]
		public void TestFixtureTearDown()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void When_finding_with_wait_Then_should_return_value()
		{
			Threaded<Session>
				.CurrentPage<SlowPageWithJQuery>()
				.TheLinkWithTimeout
				.Text
				.VerifyThat(t => t.Should().Be("The Link"));;
		}

		[Test]
		public void When_finding_with_no_wait_Then_exception_should_be_thrown()
		{
			Action action = () => Threaded<Session>
				.CurrentPage<SlowPageWithJQuery>()
				.TheLinkWithNoTimeout
				.Text
				.VerifyThat(t => t.Should().Be("The Link"));

			action.ShouldThrow<NoSuchElementException>();
		}
	}
}
