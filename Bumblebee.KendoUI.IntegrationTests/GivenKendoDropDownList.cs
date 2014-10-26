using System.Linq;
using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.KendoUI.Pages;
using Bumblebee.IntegrationTests.TestSupport.DriverEnvironments;
using Bumblebee.Setup;
using FluentAssertions;
using NUnit.Framework;

namespace Bumblebee.IntegrationTests.KendoUI
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class GivenKendoDropDownList
    {
        [SetUp]
        public void SetUp()
        {
            Threaded<Session>
                .With<LocalIeEnvironment>()
                .NavigateTo<KendoDropDownListDemoPage>(KendoDropDownListDemoPage.Url);
        }

        [TearDown]
        public void TearDown()
        {
            Threaded<Session>.End();
        }

        [Test]
        public void When_getting_selected_value_Then_gets_text()
        {
            Threaded<Session>
                .CurrentBlock<KendoDropDownListDemoPage>()
                .VerifyThat(p => p.Colors
                    .Options
                    .First(x => x.Selected)
                    .Text.Should().Be("Black"))
                .VerifyThat(p => p.Sizes
                    .Options
                    .First(x => x.Selected)
                    .Text.Should().Be("S - 6 3/4\""));
        }

        [Test]
        public void When_changing_selected_value_Then_is_updated()
        {
            Threaded<Session>
                .CurrentBlock<KendoDropDownListDemoPage>()
                .Colors
                .Options
                .First(x => x.Text == "Orange")
                .Click()
                .VerifyThat(p => p.Colors.Options.First(x => x.Selected).Text.Should().Be("Orange"))

                .Sizes
                .Options
                .First(x => x.Text == "L - 7 1/8\"")
                .Click<KendoDropDownListDemoPage>()
                .VerifyThat(p => p.Sizes.Options.First(x => x.Selected).Text.Should().Be("L - 7 1/8\""));
        }
    }
}
