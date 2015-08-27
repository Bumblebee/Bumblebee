using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

using OpenQA.Selenium.IE;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Setup.SessionTests
{
	[TestFixture]
	public class SessionTests
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
	}
}
