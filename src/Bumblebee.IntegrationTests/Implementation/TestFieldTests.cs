using System;
using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using FluentAssertions;
using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Implementation
{
	// ReSharper disable InconsistentNaming

	[TestFixture]
	public class Given_text_field : HostTestFixture
	{
		[OneTimeSetUp]
		public void Init()
		{
			Threaded<Session>
				.With<PhantomJS>()
				.NavigateTo<DateFieldPage>(String.Format("{0}/Content/TextField.html", BaseUrl));
		}

		[OneTimeTearDown]
		public void Dispose()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void When_entering_text_Then_text_should_work()
		{
			const string expectedText = "This is the text.";

			Threaded<Session>
				.CurrentBlock<TextFieldPage>()
				.Text.EnterText(expectedText)
				.VerifyThat(x => x.Text.Text.Should().Be(expectedText));
		}
	}
}
