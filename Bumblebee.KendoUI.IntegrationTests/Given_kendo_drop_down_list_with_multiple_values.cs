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
	public class Given_kendo_drop_down_list_with_multiple_values
	{
		private const string Url = "http://demos.telerik.com/kendo-ui/multiselect/api";

		[TestFixtureSetUp]
		public void Init()
		{
			Threaded<Session>
				.With<InternetExplorer>()
				.NavigateTo<KendoMultiSelectDemoPage>(Url);
		}

		[TestFixtureTearDown]
		public void Dispose()
		{
			Threaded<Session>.End();
		}

		[Test]
		public void When_selecting_multiple_values_Then_selection_occurs()
		{
			Threaded<Session>
				.CurrentBlock<KendoMultiSelectDemoPage>()
				.Movies.Options.First().Click()
				.Movies.Options.Last().Click()
				.VerifyThat(p => p.Movies.Options
					.Count(x => x.Selected)
					.Should().Be(2))
				.VerifyThat(p => p.Movies.Options
					.First().Selected
					.Should().BeTrue())
				.VerifyThat(p => p.Movies.Options
					.Last().Selected
					.Should().BeTrue());
		}

		[Test]
		public void When_selecting_and_deselecting_a_value_Then_nothing_is_selected()
		{
			Threaded<Session>
				.CurrentBlock<KendoMultiSelectDemoPage>()
				.Movies.Options.First().Click()
				.VerifyThat(p => p.Movies.Options
					.Count(x => x.Selected)
					.Should().Be(1))
				.Movies.Options
				.First()
				.Click()
				.VerifyThat(p => p.Movies.Options
					.Count(x => x.Selected)
					.Should().Be(0));
		}
	}
}
