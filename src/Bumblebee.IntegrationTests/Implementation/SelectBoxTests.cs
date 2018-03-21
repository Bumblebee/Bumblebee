using System;
using System.Linq;
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
	public class Given_select_box_with_ability_to_select_multiple_values : HostTestFixture
	{
		[OneTimeSetUp]
		public void Init()
		{
			Threaded<Session>
				.With<PhantomJS>()
				.NavigateTo<MultiSelectPage>(String.Format("{0}/Content/MultiSelect.html", BaseUrl));
		}

		[OneTimeTearDown]
		public void Dispose()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void When_selecting_multiple_values_Then_selection_occurs()
		{
			Threaded<Session>
				.CurrentBlock<MultiSelectPage>()
				.Toppings.Options.First().Click()
				.Toppings.Options.Last().Click()
				.VerifyThat(p => p.Toppings.Options
					.Count(x => x.Selected)
					.Should().Be(2))
				.VerifyThat(p => p.Toppings.Options
					.First().Selected
					.Should().BeTrue())
				.VerifyThat(p => p.Toppings.Options
					.Last().Selected
					.Should().BeTrue());
		}

		[Test]
		public void When_selecting_and_deselecting_a_value_Then_nothing_is_selected()
		{
			Threaded<Session>
				.CurrentBlock<MultiSelectPage>()
				.Toppings.Options.First().Click()
				.VerifyThat(p => p.Toppings.Options
					.Count(x => x.Selected)
					.Should().Be(1))
				.Toppings.Options.First().Click()
				.VerifyThat(p => p.Toppings.Options
					.Count(x => x.Selected)
					.Should().Be(0));
		}
	}
}
