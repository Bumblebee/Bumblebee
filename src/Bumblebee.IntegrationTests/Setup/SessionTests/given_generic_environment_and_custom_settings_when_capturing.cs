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
	public class given_generic_environment_and_custom_settings_when_capturing : HostTestFixture
	{
		private string _filePath;
		private Session _session;
		private Session _returnSession;

		[TestFixtureSetUp]
		public void Before()
		{
			var currentMethod = this.GetCurrentMethodFullName();

			const string path = @"C:\Temp";
			_filePath = Path.ChangeExtension(Path.Combine(path, currentMethod), "png");
			File.Delete(_filePath);

			var settings = new Settings
			{
				ScreenCapturePath = path
			};

			_session = new Session<InternetExplorer>(settings);
			_session.NavigateTo<CheckboxPage>(GetUrl("Checkbox.html"));
			_returnSession = _session.CaptureScreen(_filePath);
		}

		[TestFixtureTearDown]
		public void After()
		{
			_session.End();
			File.Delete(_filePath);
		}

		[Test]
		public void should_save_in_path()
		{
			File.Exists(_filePath).Should().BeTrue();
		}

		[Test]
		public void should_return_session()
		{
			_returnSession.Should().Be(_session);
		}
	}
}