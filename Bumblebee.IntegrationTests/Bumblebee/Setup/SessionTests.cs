using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

using OpenQA.Selenium.IE;

namespace Bumblebee.IntegrationTests.Bumblebee.Setup
{
	// ReSharper disable InconsistentNaming

	[TestFixture]
	public class SessionTests
	{
		[Test]
		public void given_driver_environment_instance_when_instantiating_should_set_driver_based_on_driver_environment()
		{
			var session = new Session(new InternetExplorer());
			session.Driver.Should().BeOfType<InternetExplorerDriver>();
			session.End();
		}

		[Test]
		public void given_driver_environment_type_when_instantiating_should_set_driver_based_on_driver_environment()
		{
			var session = new Session<InternetExplorer>();
			session.Driver.Should().BeOfType<InternetExplorerDriver>();
			session.End();
		}
	}
}
