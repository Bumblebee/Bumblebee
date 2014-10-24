using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var page = Threaded<Session>
                .CurrentBlock<KendoDropDownListDemoPage>();
            page.Colors.Options.First(x => x.Selected).Text.Should().Be("Black");
            page.Sizes.Options.First(x => x.Selected).Text.Should().Be("S - 6 3/4\"");
        }

        [Test]
        public void When_changing_selected_value_Then_is_updated()
        {
            var page = Threaded<Session>
                .CurrentBlock<KendoDropDownListDemoPage>();
            page.Colors.Options.First(x => x.Text == "Orange").Click();
            page.Colors.Options.First(x => x.Selected).Text.Should().Be("Orange");

            page.Sizes.Options.First(x => x.Text == "L - 7 1/8\"").Click();
            page.Sizes.Options.First(x => x.Selected).Text.Should().Be("L - 7 1/8\"");
        }
    }
}
