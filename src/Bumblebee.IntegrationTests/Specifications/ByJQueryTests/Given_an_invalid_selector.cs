using System;

using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using Bumblebee.Specifications;

using FluentAssertions;

using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Specifications.ByJQueryTests
{
	[TestFixture]
	public class Given_an_invalid_selector : HostTestFixture
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

		[Test]
		public void When_null_selector_is_provided_Then_exception_is_thrown()
		{
			Action fn = () => new ByJQuery(null);

			fn.ShouldThrow<ArgumentNullException>();
		}

		[Test]
		public void When_empty_string_selector_is_provided_Then_exception_is_thrown()
		{
			Action fn = () => new ByJQuery(String.Empty);

			fn.ShouldThrow<ArgumentNullException>();
		}

		[Test]
		public void When_whitespace_string_selector_is_provided_Then_exception_is_thrown()
		{
			Action fn = () => new ByJQuery(" \t\r\n");

			fn.ShouldThrow<ArgumentNullException>();
		}
	}
}
