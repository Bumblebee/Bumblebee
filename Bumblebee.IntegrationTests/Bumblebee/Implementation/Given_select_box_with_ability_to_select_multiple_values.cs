using System.Linq;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using FluentAssertions;
using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Bumblebee.Implementation
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class Given_select_box_with_ability_to_select_multiple_values
    {
        private const string Url = "http://www.htmlcodetutorial.com/forms/_SELECT_MULTIPLE.html";

        [TestFixtureSetUp]
        public void Init()
        {
            Threaded<Session>
                .With<PhantomJS>()
                .NavigateTo<HtmlCodeTutorialSelectMultiplePage>(Url);
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            Threaded<Session>
                .End();
        }

        [Test]
        public void When_selecting_multiple_values_Then_selection_occurs()
        {
            Threaded<Session>
                .CurrentBlock<HtmlCodeTutorialSelectMultiplePage>()
                .Toppings.Options.First().Click()
                .Toppings.Options.Last().Click()
                .VerifyThat(p => p.Toppings.Options
                    .Count(x => x.Selected)
                    .Should().Be(2))
                .VerifyThat(p => p.Toppings.Options
                    .First().Selected
                    .Should().BeTrue())
                .VerifyThat(p => p.Toppings.Options
                    .Last().Selected
                    .Should().BeTrue());
        }

        [Test]
        public void When_selecting_and_deselecting_a_value_Then_nothing_is_selected()
        {
            Threaded<Session>
                .CurrentBlock<HtmlCodeTutorialSelectMultiplePage>()
                .Toppings.Options.First().Click()
                .VerifyThat(p => p.Toppings.Options
                    .Count(x => x.Selected)
                    .Should().Be(1))
                .Toppings.Options.First().Click()
                .VerifyThat(p => p.Toppings.Options
                    .Count(x => x.Selected)
                    .Should().Be(0));
        }
    }
}
