using System.Linq;
using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.DriverEnvironments;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.Setup;
using FluentAssertions;
using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Bumblebee.Implementation
{
    [TestFixture]
    public class Given_radio_buttons : HostTestFixture
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Threaded<Session>
                .With<LocalPhantomEnvironment>()
                .NavigateTo<RadioButtonsPage>(BaseUrl + "/Content/RadioButtons.html");
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            Threaded<Session>
                .CurrentBlock<RadioButtonsPage>()
                .Session.End();
        }

        [TestCase("Water", false)]
        [TestCase("Beer", false)]
        [TestCase("Wine", true)]
        public void Given_option_exists_by_text_When_checking_if_selected_Then_returns_expected(string text, bool expected)
        {
            Threaded<Session>
                .CurrentBlock<RadioButtonsPage>()
                .VerifyThat(p => p.Beverages
                    .Options.WithText(text)
                    .First()
                    .Selected
                    .Should().Be(expected));
        }

        [Test]
        public void Given_option_does_not_exist_When_selecting_by_text_Then_should_not_find_any()
        {
            Threaded<Session>
                .CurrentBlock<RadioButtonsPage>()
                .VerifyThat(p => p.Beverages
                    .Options.WithText("Test")
                    .Any()
                    .Should().BeFalse());
        }
    }
}
