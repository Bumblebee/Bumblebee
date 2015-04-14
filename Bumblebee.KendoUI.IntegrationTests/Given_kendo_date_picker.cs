using System;
using System.Globalization;

using Bumblebee.Extensions;
using Bumblebee.KendoUI.IntegrationTests.Pages;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.KendoUI.IntegrationTests
{
	// ReSharper disable InconsistentNaming

	[TestFixture]
	public class Given_kendo_date_picker
	{
		private const string Url = "http://demos.telerik.com/kendo-ui/datepicker/index";

		[TestFixtureSetUp]
		public void Init()
		{
			Threaded<Session>
				.With<InternetExplorer>()
				.NavigateTo<KendoDatePickerDemoPage>(Url);
		}

		[TestFixtureTearDown]
		public void Dispose()
		{
			Threaded<Session>.End();
		}

		[Test]
		public void When_reading_default_date_Then_reads_text_and_value()
		{
			Threaded<Session>
				.CurrentBlock<KendoDatePickerDemoPage>()
				.VerifyThat(p => p.DateFrom.Text.Should().Be("2011-10-10"))
				.VerifyThat(p => p.DateFrom.Value.Should().Be(DateTime.Parse("2011-10-10")));
		}

		[Test]
		public void When_writing_date_Then_writes_and_reads_text_and_value()
		{
			Threaded<Session>
				.CurrentBlock<KendoDatePickerDemoPage>()
				.DateFrom.EnterDate(DateTime.Today)
				.VerifyThat(p => p.DateFrom.Text.Should().Be(DateTime.Today.ToString("yyyy-MM-dd")))
				.VerifyThat(p => p.DateFrom.Value.Should().Be(DateTime.Today));
		}

		[Test]
		public void When_writing_date_as_text_Then_writes_and_reads_text_and_value()
		{
			Threaded<Session>
				.CurrentBlock<KendoDatePickerDemoPage>()
				.DateFrom.EnterText(DateTime.Today.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture))
				.VerifyThat(p => p.DateFrom.Text.Should().Be(DateTime.Today.ToString("yyyy-MM-dd")))
				.VerifyThat(p => p.DateFrom.Value.Should().Be(DateTime.Today));
		}
	}
}
