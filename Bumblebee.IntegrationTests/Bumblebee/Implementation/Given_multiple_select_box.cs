using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.DriverEnvironments;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Bumblebee.Implementation
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class Given_multiple_select_box
    {
        private const string Url = "http://www.htmlcodetutorial.com/forms/_SELECT_MULTIPLE.html";

        [TestFixtureSetUp]
        public void Init()
        {
            Threaded<Session>
                .With<LocalPhantomEnvironment>()
                .NavigateTo<HtmlCodeTutorialSelectMultiplePage>(Url);
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            Threaded<Session>.End();
        }

        [Test]
        public void When_selecting_multiple_values_Then_selection_occurs()
        {
            Threaded<Session>
                .CurrentBlock<HtmlCodeTutorialSelectMultiplePage>()
                .Toppings.Options.First().Click()
                .Toppings.Options.Last().Click()
                .Verify(p => p.Toppings.Options.Count(x => x.Selected) == 2)
                .Verify(p => p.Toppings.Options.First().Selected)
                .Verify(p => p.Toppings.Options.Last().Selected);
        }

        [Test]
        public void When_selecting_and_deselecting_a_value_Then_nothing_is_selected()
        {
            Threaded<Session>
                .CurrentBlock<HtmlCodeTutorialSelectMultiplePage>()
                .Toppings.Options.First().Click()
                .Verify(p => p.Toppings.Options.Count(x => x.Selected) == 1)
                .Toppings.Options.First().Click()
                .Verify(p => p.Toppings.Options.Count(x => x.Selected) == 0);
        }
    }
}
