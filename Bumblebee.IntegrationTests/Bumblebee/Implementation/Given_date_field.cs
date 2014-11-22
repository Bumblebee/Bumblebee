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
    public class Given_date_field
    {
        private const string Url = "http://www.wufoo.com/html5/example/";

        [TestFixtureSetUp]
        public void Init()
        {
            Threaded<Session>
                .With<LocalPhantomEnvironment>()
                .NavigateTo<WufooHtml5ExamplesPage>(Url);
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
                .Date.EnterDate(DateTime.Today)
                .VerifyThat(x => x.Date.Value.Should().Be(DateTime.Today))
                .VerifyThat(x => x.Date.Text.Should().Be(DateTime.Today.ToString("yyyy-MM-dd")));
}
    }
}
