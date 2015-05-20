using System;
using System.Linq;

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
	public class Given_list_of_complex_blocks : HostTestFixture
	{
		[SetUp]
		public void TestSetUp()
		{
			Threaded<Session>
				.With<PhantomJS>()
				.NavigateTo<ListOfComplexBlocksPage>(String.Format("{0}/Content/ListOfComplexBlocks.html", BaseUrl));
		}

		[TearDown]
		public void TestTearDown()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void When_picking_the_second_item_in_the_list_it_is_fluently_returned_by_its_child_elements()
		{
			Threaded<Session>
				.CurrentBlock<ListOfComplexBlocksPage>()
				.List
				.Items.Skip(1).First()
				.TextField.EnterText("Hello, World!")
				.SelectBox.Options.WithText("Two").Single().Click()
				.Button.Click<ListOfComplexBlocksPage>()
				.VerifyThat(x =>
					x.ButtonClicked
						.Should()
						.Be(x.DropDownClicked)
						.And.Be(x.TextBoxChanged));
		}

		[Test]
		public void When_picking_a_random_item_in_the_list_it_is_fluently_returned_by_its_child_elements()
		{
			Threaded<Session>
				.CurrentBlock<ListOfComplexBlocksPage>()
				.List
				.Items.Random()
				.TextField.EnterText("Hello, World!")
				.SelectBox.Options.WithText("Two").Single().Click()
				.Button.Click<ListOfComplexBlocksPage>()
				.VerifyThat(x =>
					x.ButtonClicked
						.Should()
						.Be(x.DropDownClicked)
						.And.Be(x.TextBoxChanged));
		}
	}
}
