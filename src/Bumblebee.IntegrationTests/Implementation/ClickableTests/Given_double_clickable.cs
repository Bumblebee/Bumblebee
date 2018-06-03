using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.Setup;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Implementation.ClickableTests
{
	// ReSharper disable InconsistentNaming

	[TestFixture(typeof(HeadlessChrome))]
	public class Given_double_clickable<T> : HostTestFixture
		where T : IDriverEnvironment, new()
	{
		[OneTimeSetUp]
		public void TestFixtureSetUp()
		{
			Threaded<Session>
				.With<T>()
				.NavigateTo<DoubleClickablePage>(GetUrl("DoubleClick.html"));
		}

		[OneTimeTearDown]
		public void TestFixtureTearDown()
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
