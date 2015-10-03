using System;

using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Implementation
{
	[TestFixture]
	public class given_web_page_with_explicit_wait : HostTestFixture
	{
		[SetUp]
		public void TestSetUp()
		{
			Threaded<Session>
				.With(new PhantomJS(TimeSpan.FromSeconds(0)))
				.NavigateTo<SlowWebPageWithExplicitWait>(GetUrl("SlowWebPage.html"));
		}

		[TearDown]
		public void TestDispose()
		{
			Threaded<Session>
				.CurrentBlock<SlowWebPageWithExplicitWait>()
				.Session.End();
		}

		[Test]
		public void given_slow_load_when_getting_an_element_using_wait_should_wait()
		{
			Threaded<Session>
				.CurrentBlock<SlowWebPageWithExplicitWait>()
				.FirstName
				.Text
				.Should().Be("Todd");
		}
	}
}