using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Setup.SessionTests
{
	[TestFixture]
	public class Given_user_has_navigated_to_a_page : HostTestFixture
	{
		private Session _session;

		[SetUp]
		public void TestSetUp()
		{
			_session = new Session(new PhantomJS());
			_session.NavigateTo<DefaultPage>(GetUrl("Default.html"));
		}

		[TearDown]
		public void TestTearDown()
		{
			_session
				.End();
		}

		[Test]
		public void When_getting_current_page_as_correct_type_Then_should_return_page()
		{
			_session
				.CurrentPage<DefaultPage>()
				.VerifyThat(p => AssertionExtensions.Should((object) p).NotBeNull())
				.VerifyThat(p => p.Should().BeOfType<DefaultPage>());
		}

		[Test]
		public void When_getting_current_page_as_incorrect_type_Then_should_return_page()
		{
			_session
				.CurrentPage<KeysPage>()
				.VerifyThat(p => p.Should().NotBeNull())
				.VerifyThat(p => p.Should().BeOfType<KeysPage>());
		}
	}
}