using System.IO;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Setup.SessionTests
{
	[TestFixture]
	public class given_environment_and_default_settings_when_capturing : HostTestFixture
	{
		private string path;
		private Session session;
		private Session _returnSession;

		[TestFixtureSetUp]
		public void Before()
		{
			var currentMethod = this.GetCurrentMethodName();
			var defaultSettings = new Settings();
			path = Path.ChangeExtension(Path.Combine(defaultSettings.ScreenCapturePath, currentMethod), "png");
			File.Delete(path);

			var environment = new InternetExplorer();
			session = new Session(environment);
			session.NavigateTo<CheckboxPage>(GetUrl("Checkbox.html"));
			_returnSession = session.CaptureScreen();
		}

		[TestFixtureTearDown]
		public void After()
		{
			session.End();
			File.Delete(path);
		}

		[Test]
		public void should_save_in_executing_directory()
		{
			File.Exists(path).Should().BeTrue();
		}

		[Test]
		public void should_return_session()
		{
			_returnSession.Should().Be(session);
		}
	}
}