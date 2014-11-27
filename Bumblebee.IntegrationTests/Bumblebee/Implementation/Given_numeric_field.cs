using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.DriverEnvironments;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Bumblebee.Implementation
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class Given_numeric_field
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Threaded<Session>
                .With<LocalPhantomEnvironment>()
                .NavigateTo<WufooHtml5ExamplesPage>(WufooHtml5ExamplesPage.Url);
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            Threaded<Session>.End();
        }

        [Test]
        public void When_entering_date_Then_text_and_value_work()
        {
            Threaded<Session>
                .CurrentBlock<WufooHtml5ExamplesPage>()
                .Number.EnterNumber(456789.123456)
                .VerifyThat(x => x.Number.Value.Should().Be(456789.123456))
                .VerifyThat(x => x.Number.Text.Should().Be("456789.123456"));
        }
    }
}
