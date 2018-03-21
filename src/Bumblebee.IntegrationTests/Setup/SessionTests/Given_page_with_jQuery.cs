using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Setup.SessionTests
{
	[TestFixture]
	public class Given_page_with_jQuery : HostTestFixture
	{
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			Threaded<Session>
				.With<PhantomJS>()
				.NavigateTo<PageWithJQuery>(GetUrl("PageWithJQuery.html"));
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void HasJQuery()
		{
			Threaded<Session>
				.CurrentBlock<PageWithJQuery>()
				.Session.HasJQuery()
				.Should().BeTrue();
		}
	}
}
