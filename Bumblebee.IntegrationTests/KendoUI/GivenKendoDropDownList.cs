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
                .NavigateTo<KendoDropDownListDemoPage>("http://demos.telerik.com/kendo-ui/dropdownlist/index");
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
        }

        [Test]
        public void When_changing_selected_value_Then_is_updated()
        {
            var page = Threaded<Session>
                .CurrentBlock<KendoDropDownListDemoPage>();
            page.Colors.Options.First(x => x.Text == "Orange").Click();
            page.Colors.Options.First(x => x.Selected).Text.Should().Be("Orange");
        }
    }
}
