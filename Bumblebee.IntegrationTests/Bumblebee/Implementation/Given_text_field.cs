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
    public class Given_text_field
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
        public void When_entering_text_Then_text_should_work()
        {
            const string expectedText = "This is the text.";

            Threaded<Session>
                .CurrentBlock<WufooHtml5ExamplesPage>()
                .Placeholder.EnterText(expectedText)
                .VerifyThat(x => x.Placeholder.Text.Should().Be(expectedText));
        }

        [Test]
        public void When_label_Then_text_should_work()
        {
            const string expectedText = "Placeholder";

            Threaded<Session>
                .CurrentBlock<WufooHtml5ExamplesPage>()
                .VerifyThat(x => x.PlaceholderLabel.Should().Be(expectedText));
        }
    }
}