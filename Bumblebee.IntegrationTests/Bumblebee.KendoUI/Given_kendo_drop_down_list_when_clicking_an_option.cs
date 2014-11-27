using System.Linq;
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
    public class Given_kendo_drop_down_list_when_clicking_an_option
    {
        private const string Url = "http://demos.telerik.com/kendo-ui/dropdownlist/index";
        private const string TextForSizeOption = "L - 7 1/8\"";

        [TestFixtureSetUp]
        public void Init()
        {
            Threaded<Session>
                .With<LocalIeEnvironment>()
                .NavigateTo<KendoDropDownListDemoPage>(Url)
                .Sizes
                .Options
                .First(x => x.Text == TextForSizeOption)
                .Click<KendoDropDownListDemoPage>();
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            Threaded<Session>.End();
        }

        [Test]
        public void Then_option_should_be_selected()
        {
            Threaded<Session>
                .CurrentBlock<KendoDropDownListDemoPage>()
                .VerifyThat(p => p.Sizes
                    .Options.First(x => x.Text == TextForSizeOption)
                    .Selected.Should().BeTrue());
        }

        [Test]
        public void Then_other_options_should_not_be_selected()
        {
            Threaded<Session>
                .CurrentBlock<KendoDropDownListDemoPage>()
                .VerifyThat(p => p.Sizes
                    .Options
                    .Where(x => x.Text != TextForSizeOption).ToList()
                    .ForEach(x => x.Selected.Should().BeFalse()));
        }
    }
}