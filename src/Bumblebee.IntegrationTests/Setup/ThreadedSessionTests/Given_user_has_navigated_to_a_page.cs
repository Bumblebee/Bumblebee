using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Setup.ThreadedSessionTests
{
	[TestFixture]
	public class Given_user_has_navigated_to_a_page : HostTestFixture
	{
		[SetUp]
		public void SetUp()
		{
			Threaded<Session>
				.With<PhantomJS>()
				.NavigateTo<DefaultPage>(GetUrl("Default.html"));
		}

		[TearDown]
		public void Dispose()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void When_getting_current_page_as_correct_type_THen_should_return_page()
		{
			Threaded<Session>
				.CurrentPage<DefaultPage>()
				.VerifyThat(p => p.Should().NotBeNull())
				.VerifyThat(p => p.Should().BeOfType<DefaultPage>());
		}

		[Test]
		public void When_getting_current_page_as_incorrect_type_Then_should_return_page()
		{
			Threaded<Session>
				.CurrentPage<KeysPage>()
				.VerifyThat(p => p.Should().NotBeNull())
				.VerifyThat(p => p.Should().BeOfType<KeysPage>());
		}
	}
}