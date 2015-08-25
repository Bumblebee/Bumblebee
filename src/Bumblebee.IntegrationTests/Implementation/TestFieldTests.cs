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
	public class Given_text_field : HostTestFixture
	{
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			Threaded<Session>
				.With<PhantomJS>()
				.NavigateTo<DateFieldPage>(GetUrl("TextField.html"));
		}

		[TestFixtureTearDown]
		public void TestFixtureTearDown()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void When_entering_text_Then_text_should_work()
		{
			const string expectedText = "This is the text.";

			Threaded<Session>
				.CurrentBlock<TextFieldPage>()
				.Text.EnterText(expectedText)
				.VerifyThat(x => x.Text.Text.Should().Be(expectedText));
		}
	}
}
