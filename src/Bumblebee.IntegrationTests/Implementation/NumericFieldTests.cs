using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.Setup;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Implementation
{
	// ReSharper disable InconsistentNaming
	[TestFixture(typeof(HeadlessChrome))]
	public class Given_numeric_field<T> : HostTestFixture
		where T : IDriverEnvironment, new()
	{
		[OneTimeSetUp]
		public void TestFixtureSetUp()
		{
			Threaded<Session>
				.With<T>()
				.NavigateTo<NumericFieldPage>(GetUrl("NumericField.html"));
		}

		[OneTimeTearDown]
		public void TestFixtureTearDown()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void When_entering_number_Then_text_and_value_work()
		{
			Threaded<Session>
				.CurrentBlock<NumericFieldPage>()
				.Number.EnterNumber(5)
				.VerifyThat(x => x.Number.Value.Should().Be(5))
				.VerifyThat(x => x.Number.Text.Should().Be("5"));
		}
	}
}
