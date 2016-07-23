using System;

using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

using OpenQA.Selenium;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Implementation.WebPageTests
{
	[TestFixture]
	public class Given_slow_web_page_with_no_wait : HostTestFixture
	{
		[SetUp]
		public void TestSetUp()
		{
			Threaded<Session>
				.With(new PhantomJS(TimeSpan.FromSeconds(0)))
				.NavigateTo<SlowWebPageWithNoWait>(GetUrl("SlowWebPage.html"));
		}

		[TearDown]
		public void TestDispose()
		{
			Threaded<Session>
				.CurrentBlock<SlowWebPageWithNoWait>()
				.Session.End();
		}

		[Test]
		public void When_getting_text_of_textfield_Should_throw()
		{
			Action action = () =>
				Threaded<Session>
					.CurrentBlock<SlowWebPageWithNoWait>()
					.FirstName
					.Text
					.Should().Be("Todd");

			action
				.ShouldThrow<WebDriverTimeoutException>()
				.WithMessage("Timed out after 0 seconds");
		}

		[Test]
		public void When_getting_checked_indicator_for_checkbox_should_throw()
		{
			Action action = () =>
				Threaded<Session>
					.CurrentBlock<SlowWebPageWithNoWait>()
					.Checkbox
					.Selected
					.Should().BeTrue();

			action
				.ShouldThrow<WebDriverTimeoutException>()
				.WithMessage("Timed out after 0 seconds");
		}
	}
}
