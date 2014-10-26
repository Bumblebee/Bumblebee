using System.Linq;
using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Bumblebee.KendoUI.Pages;
using Bumblebee.IntegrationTests.Shared.DriverEnvironments;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using FluentAssertions;
using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Bumblebee.KendoUI
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class Given_page_with_kendoui_drop_down_lists_and_no_options_selected
    {
        public const string Url = "http://demos.telerik.com/kendo-ui/dropdownlist/index";

        [TestFixtureSetUp]
        public void Init()
        {
            Threaded<Session>
                .With<LocalIeEnvironment>()
                .NavigateTo<KendoDropDownListDemoPage>(Url);
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            Threaded<Session>.End();
        }

        [Test]
        public void When_getting_text_for_options_Then_should_return_text_for_each_option()
        {
            Threaded<Session>
                .CurrentBlock<KendoDropDownListDemoPage>()
                .VerifyThat(p => p.Sizes
                    .Options
                    .Select(o => o.Text)
                    .Should().ContainInOrder("S - 6 3/4\"", "M - 7 1/4\"", "L - 7 1/8\"", "XL - 7 5/8\""));
        }

        [Test]
        public void Given_no_option_selected_Then_no_option_should_be_selected()
        {
            Threaded<Session>
                .CurrentBlock<KendoDropDownListDemoPage>()
                .VerifyThat(p => p.Colors.Options.Select(o => o.Selected).Should().BeEmpty());
        }
    }

    [TestFixture]
    public class Given_kendo_drop_down_list_when_clicking_an_option
    {
        const string Url = "http://demos.telerik.com/kendo-ui/dropdownlist/index";
        const string textForSizeOption = "L - 7 1/8\"";

        [TestFixtureSetUp]
        public void Init()
        {
            Threaded<Session>
                .With<LocalIeEnvironment>()
                .NavigateTo<KendoDropDownListDemoPage>(Url)
                .Sizes
                .Options
                .First(x => x.Text == textForSizeOption)
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
                    .Options
                    .First(x => x.Text == textForSizeOption)
                    .Selected.Should().BeTrue());
        }

        [Test]
        public void Then_other_options_should_not_be_selected()
        {
            Threaded<Session>
                .CurrentBlock<KendoDropDownListDemoPage>()
                .VerifyThat(p => p.Sizes
                    .Options
                    .Where(x => x.Text != textForSizeOption).ToList()
                    .ForEach(x => x.Selected.Should().BeFalse()));
        }
    }
}
