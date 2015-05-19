using System.Linq;

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
	public class Given_kendo_drop_down_list_and_no_options_selected
	{
		public const string Url = "http://demos.telerik.com/kendo-ui/dropdownlist/index";

		[TestFixtureSetUp]
		public void Init()
		{
			Threaded<Session>
				.With<InternetExplorer>()
				.NavigateTo<KendoDropDownListDemoPage>(Url);
		}

		[TestFixtureTearDown]
		public void Dispose()
		{
			Threaded<Session>.End();
		}

		[Test]
		public void When_getting_text_for_options_Then_should_return_text_for_each_option()
		{
			Threaded<Session>
				.CurrentBlock<KendoDropDownListDemoPage>()
				.VerifyThat(p => p.Sizes
					.Options
					.Select(o => o.Text)
					.Should().ContainInOrder("S - 6 3/4\"", "M - 7 1/4\"", "L - 7 1/8\"", "XL - 7 5/8\""));
		}

		[Test]
		public void Given_default_option_selected_Then_only_one_option_should_be_selected()
		{
			Threaded<Session>
				.CurrentBlock<KendoDropDownListDemoPage>()
				.VerifyThat(p => p.Colors
					.Options
					.Where(o => o.Selected)
					.Should().HaveCount(1));
		}
	}
}
