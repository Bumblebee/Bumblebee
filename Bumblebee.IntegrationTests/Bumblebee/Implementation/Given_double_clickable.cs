using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using FluentAssertions;
using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Bumblebee.Implementation
{
    [TestFixture]
    public class Given_double_clickable : HostTestFixture
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Threaded<Session>
                .With<PhantomJS>()
                .NavigateTo<DoubleClickablePage>(BaseUrl + "/Content/DoubleClick.html");
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            Threaded<Session>
                .End();
        }

        [Test]
        public void When_double_clicking_element_with_static_page_Then_should_toggle_result()
        {
            Threaded<Session>
                .CurrentBlock<DoubleClickablePage>()
                .ParagraphWithStaticPage.DoubleClick()
                .VerifyThat(p => p.Result.Should().Be("Hello, World!"))
                .ParagraphWithStaticPage.DoubleClick()
                .VerifyThat(p => p.Result.Should().BeEmpty());
        }

        [Test]
        public void When_double_clicking_element_with_dynamic_page_Then_should_toggle_result()
        {
            Threaded<Session>
                .CurrentBlock<DoubleClickablePage>()
                .ParagraphWithDynamicPage.DoubleClick<DoubleClickablePage>()
                .VerifyThat(p => p.Result.Should().Be("Hello, World!"))
                .ParagraphWithDynamicPage.DoubleClick<DoubleClickablePage>()
                .VerifyThat(p => p.Result.Should().BeEmpty());
        }
    }
}