using System;
using System.Linq;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.DriverEnvironments;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Bumblebee.Implementation
{
    public class TableRow
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class Given_table : HostTestFixture
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Threaded<Session>
                .With<LocalPhantomEnvironment>()
                .NavigateTo<TablePage>(String.Format("{0}{1}", BaseUrl, "/Content/Table.html"));
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Session.End();
        }

        [Test]
        public void Should_contain_three_columns()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Columns
                    .Count()
                    .Should()
                    .Be(3));
        }

        [Test]
        public void Should_contain_three_rows()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
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
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()["Item"]
                    .Should()
                    .Be("Wine"));
        }

        [Test]
        public void Should_contain_first_row_with_first_column_of_wine()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()[0]
                    .Should()
                    .Be("Wine"));
        }

        [Test]
        public void Should_contain_first_row_with_quantity_of_four()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()["Quantity"]
                    .Should()
                    .Be("4"));
        }

        [Test]
        public void Should_contain_first_row_with_second_column_of_four()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()[1]
                    .Should()
                    .Be("4"));
        }

        [Test]
        public void Should_contain_first_row_with_price_of_65()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()["Price"]
                    .Should()
                    .Be("65.00"));
        }

        [Test]
        public void Should_contain_first_row_with_third_column_of_65()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()[2]
                    .Should()
                    .Be("65.00"));
        }

        [Test]
        public void Should_create_row_instances_using_reflection()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .CreateInstances<TableRow>()
                .VerifyThat(x => x
                    .Count()
                    .Should()
                    .Be(3));
        }

        [Test]
        public void Should_create_row_instances_using_reflection_and_hydrate_item_property()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .CreateInstances<TableRow>()
                .VerifyThat(x => x
                    .Select(z => z.Item)
                    .Should()
                    .BeEquivalentTo("Wine", "Beer", "Champagne"));
        }

        [Test]
        public void Should_create_row_instances_using_reflection_and_hydrate_quantity_property()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .CreateInstances<TableRow>()
                .VerifyThat(x => x
                    .Select(z => z.Quantity)
                    .Should()
                    .BeEquivalentTo(4, 2, 3));
        }

        [Test]
        public void Should_create_row_instances_using_reflection_and_hydrate_price_property()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .CreateInstances<TableRow>()
                .VerifyThat(x => x
                    .Select(z => z.Price)
                    .Should()
                    .BeEquivalentTo(65.0m, 10.0m, 100.0m));
        }
    }
}
