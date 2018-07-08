using Bumblebee.IntegrationTests.Shared;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.Setup;

using FluentAssertions;

using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Implementation.PageTests
{
	[TestFixture(typeof(HeadlessChromeWithNoWaitTime))]
	public class Given_slow_page_with_explicit_wait<T> : HostTestFixture
	    where T : IDriverEnvironment, new()
    {
		[SetUp]
		public void TestSetUp()
		{
			Threaded<Session>
				.With<T>()
				.NavigateTo<SlowPageWithExplicitWait>(GetUrl("SlowPage.html"));
		}

		[TearDown]
		public void TestDispose()
		{
			Threaded<Session>
				.CurrentBlock<SlowPageWithExplicitWait>()
				.Session.End();
		}

		[Test]
		public void When_getting_text_of_textfield_using_wait_Should_wait()
		{
			Threaded<Session>
				.CurrentBlock<SlowPageWithExplicitWait>()
				.FirstName
				.Text
				.Should().Be("Todd");
		}

		[Test]
		public void When_getting_checked_indicator_of_checkbox_using_wait_Should_wait()
		{
			Threaded<Session>
				.CurrentBlock<SlowPageWithExplicitWait>()
				.Checkbox
				.Selected
				.Should().BeTrue();
		}
	}
}
