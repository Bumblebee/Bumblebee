using System;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

using OpenQA.Selenium.IE;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Setup.SessionTests
{
	[TestFixture]
	public class SessionTests : HostTestFixture
	{
		[Test]
		public void Given_driver_environment_instance_When_instantiating_Should_set_driver_based_on_driver_environment()
		{
			var session = new Session(new InternetExplorer());
			session.Driver.Should().BeOfType<InternetExplorerDriver>();
			session.End();
		}

		[Test]
		public void Given_driver_environment_type_When_instantiating_Should_set_driver_based_on_driver_environment()
		{
			var session = new Session<InternetExplorer>();
			session.Driver.Should().BeOfType<InternetExplorerDriver>();
			session.End();
		}

		[Test]
		public void given_session_when_navigating_to_url_should_redirect_to_url()
		{
			var url = GetUrl("Default.html");
			var session = new Session<PhantomJS>();
			session
				.NavigateTo<DefaultPage>(url)
				.VerifyThat(p => p
					.Session
					.Driver
					.Url
					.Should().Be(url))
				.Session.End();
		}

		[Test]
		public void given_session_when_navigating_to_url_with_arguments_should_redirect_to_formatted_url()
		{
			var urlFormat = GetUrl("Default.html?id={0}&firstName={1}&lastName={2}");
			var session = new Session<PhantomJS>();
			session
				.NavigateTo<DefaultPage>(urlFormat, 1, "Todd", "Meinershagen")
				.VerifyThat(p => p
					.Session
					.Driver
					.Url
					.Should().Be(GetUrl("Default.html?id=1&firstName=Todd&lastName=Meinershagen")))
				.Session.End();
		}
	}
}
