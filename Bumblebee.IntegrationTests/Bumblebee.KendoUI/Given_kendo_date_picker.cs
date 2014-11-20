using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.DriverEnvironments;
using Bumblebee.IntegrationTests.Shared.Pages.KendoUI;
using Bumblebee.Setup;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Bumblebee.KendoUI
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
                .With<LocalIeEnvironment>()
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
                .VerifyThat(p => p.DateFrom.Value.Should().Be(DateTime.Parse("2011-10-10")))
                .VerifyThat(p => p.DateFrom.Text.Should().Be("2011-10-10"));
        }

        [Test]
        public void When_writing_date_Then_writes_and_reads_text_and_value()
        {
            Threaded<Session>
                .CurrentBlock<KendoDatePickerDemoPage>()
                .DateFrom.EnterDate(DateTime.Today)
                .VerifyThat(p => p.DateFrom.Value.Should().Be(DateTime.Today))
                .VerifyThat(p => p.DateFrom.Text.Should().Be(DateTime.Today.ToString("yyyy-MM-dd")));
        }
    }
}
