using System;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Bumblebee.Implementation
{
	// ReSharper disable InconsistentNaming

	[TestFixture]
	public class Given_date_field : HostTestFixture
	{
		[TestFixtureSetUp]
		public void Init()
		{
			Threaded<Session>
				.With<PhantomJS>()
				.NavigateTo<DateFieldPage>(String.Format("{0}/Content/DateField.html", BaseUrl));
		}

		[TestFixtureTearDown]
		public void Dispose()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void When_entering_date_Then_text_and_value_work()
		{
			Threaded<Session>
				.CurrentBlock<DateFieldPage>()
				.Date.EnterDate(DateTime.Today)
				.VerifyThat(x => x.Date.Value
					.Should().Be(DateTime.Today))
				.VerifyThat(x => x.Date.Text
					.Should().Be(DateTime.Today.ToString("yyyy-MM-dd")));
		}
	}
}
