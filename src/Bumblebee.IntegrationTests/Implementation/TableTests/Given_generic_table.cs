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
	public class Given_generic_table : HostTestFixture
	{
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			Threaded<Session>
				.With<PhantomJS>()
				.NavigateTo<GenericTablePage>(String.Format("{0}{1}", BaseUrl, "/Content/Table.html"));
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void Should_contain_three_columns()
		{
			Threaded<Session>
				.CurrentBlock<GenericTablePage>()
				.Table
				.VerifyThat(x => x.Headers
					.Count()
					.Should()
					.Be(3));
		}

		[Test]
		public void Should_contain_three_rows()
		{
			Threaded<Session>
				.CurrentBlock<GenericTablePage>()
				.Table
				.VerifyThat(x => x.Rows
					.Count()
					.Should()
					.Be(3));
		}

		[Test]
		public void Should_contain_first_row_with_item_of_wine()
		{
			Threaded<Session>
				.CurrentBlock<GenericTablePage>()
				.Table
				.VerifyThat(x => x.RowsAs<GenericTableRow>()
					.First()
					.Item
					.Should()
					.Be("Wine"));
		}

		[Test]
		public void Should_contain_first_row_with_quantity_of_four()
		{
			Threaded<Session>
				.CurrentBlock<GenericTablePage>()
				.Table
				.VerifyThat(x => x.RowsAs<GenericTableRow>()
					.First()
					.Quantity
					.Should()
					.Be(4));
		}

		[Test]
		public void Should_contain_first_row_with_price_of_65()
		{
			Threaded<Session>
				.CurrentBlock<GenericTablePage>()
				.Table
				.VerifyThat(x => x.RowsAs<GenericTableRow>()
					.First()
					.Price
					.Should()
					.Be(65.00m));
		}
	}
}
