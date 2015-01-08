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
            Threaded<Session>
                .End();
        }

        [Test]
        public void When_entering_number_Then_text_and_value_work()
        {
            Threaded<Session>
                .CurrentBlock<WufooHtml5ExamplesPage>()
                .Number.EnterNumber(5)
                .VerifyThat(x => AssertionExtensions.Should((double?) x.Number.Value).Be(5))
                .VerifyThat(x => x.Number.Text
                    .Should().Be("5"));
        }
    }
}
