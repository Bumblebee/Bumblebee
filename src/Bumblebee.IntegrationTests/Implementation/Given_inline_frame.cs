using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Implementation
{
	// ReSharper disable InconsistentNaming

	[TestFixture]
	public class Given_inline_frame : HostTestFixture
	{
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			Threaded<Session>
				.With<Chrome>()
				.NavigateTo<InlineFramesPage>(GetUrl("InlineFrames.html"));
		}

		[TestFixtureTearDown]
		public void TestFixtureTearDown()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void When_parent_link_is_clicked_Then_parent_text_changes()
		{
			Threaded<Session>
				.CurrentBlock<InlineFramesPage>()
				.Child.TheLink.Click()
				.VerifyThat(page => page.Text.Should().Be("Clicked."));
		}
	}
}
