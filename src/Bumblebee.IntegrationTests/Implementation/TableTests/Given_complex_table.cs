using System;
using System.Linq;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Implementation.TableTests
{
	// ReSharper disable InconsistentNaming
	[TestFixture]
	public class Given_complex_table : HostTestFixture
	{
		[SetUp]
		public void TestSetUp()
		{
			Threaded<Session>
				.With<PhantomJS>()
				.NavigateTo<ComplexTablePage>(String.Format("{0}{1}", BaseUrl, "/Content/ComplexTable.html"));
		}

		[TearDown]
		public void TestTearDown()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void Should_contain_two_columns()
		{
			Threaded<Session>
				.CurrentBlock<ComplexTablePage>()
				.Table
				.VerifyThat(x => x.Headers
					.Count()
					.Should()
					.Be(2));
		}

		[Test]
		public void Should_contain_two_rows()
		{
			Threaded<Session>
				.CurrentBlock<ComplexTablePage>()
				.Table
				.VerifyThat(x => x.Rows
					.Count()
					.Should()
					.Be(2));
		}

		[Test]
		public void Should_go_to_table_page_when_table_link_is_clicked()
		{
			Threaded<Session>
				.CurrentBlock<ComplexTablePage>()
				.Table
				.RowsAs<ComplexTableRow>().First()
				.TablePageLink.Click()
				.Table
				.VerifyThat(x => x.Rows
					.Count()
					.Should()
					.Be(3));
		}

		[TestCase("Water", false)]
		[TestCase("Beer", false)]
		[TestCase("Wine", true)]
		public void Should_go_to_radio_button_page_when_radio_link_is_clicked(string text, bool expected)
		{
			Threaded<Session>
				.CurrentBlock<ComplexTablePage>()
				.Table
				.RowsAs<ComplexTableRow>().First()
				.RadioButtonPageLink.Click()
				.VerifyThat(p =>
					p.Beverages.Options.WithText(text).Single().Selected
						.Should().Be(expected)
				);
		}
	}
}
