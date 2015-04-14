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
	public class Given_kendo_numeric_text_box_when_entering_value
	{
		public const string Url = "http://demos.telerik.com/kendo-ui/numerictextbox/index";

		[SetUp]
		public void Init()
		{
			Threaded<Session>
				.With<InternetExplorer>()
				.NavigateTo<KendoNumericTextBoxDemoPage>(Url);
		}

		[TearDown]
		public void Dispose()
		{
			Threaded<Session>.End();
		}

		[Test]
		public void When_getting_current_value_Then_parses_double()
		{
			Threaded<Session>
				.CurrentBlock<KendoNumericTextBoxDemoPage>()
				.VerifyThat(p => p.Price.Text.Should().Be("$30.00"))
				.VerifyThat(p => p.Price.Value.Should().Be(30));
		}

		[Test]
		public void When_setting_current_value_Then_enters_text_and_parses_double()
		{
			Threaded<Session>
				.CurrentBlock<KendoNumericTextBoxDemoPage>()
				.Price.EnterNumber(45.12)
				.VerifyThat(p => p.Price.Text.Should().Be("$45.12"))
				.VerifyThat(p => p.Price.Value.Should().Be(45.12));
		}

		[Test]
		public void When_setting_current_value_as_text_Then_enters_text_and_parses_double()
		{
			Threaded<Session>
				.CurrentBlock<KendoNumericTextBoxDemoPage>()
				.Price.EnterText("45.12")
				.VerifyThat(p => p.Price.Text.Should().Be("$45.12"))
				.VerifyThat(p => p.Price.Value.Should().Be(45.12));
		}
	}
}
