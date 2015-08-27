using System;
using System.IO;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Setup.SessionTests
{
    [TestFixture]

    public class Given_environment_and_default_settings_When_capturing_from_generic_method : HostTestFixture
    {
        [Test]
        public void should_save_in_executing_directory()
        {
            var environment = new InternetExplorer();
            var session = new Session(environment);
            session.NavigateTo<CheckboxPage>(GetUrl("Checkbox.html"));

            var path = GenericMethod(session);

            File.Exists(path).Should().BeTrue();

            session.End();
            File.Delete(path);
        }

        private string GenericMethod<T>(T session) where T:Session
        {
            var currentMethod = String.Format("{0}.png", CallStack.GetCurrentMethod().GetFullName());
            var defaultSettings = new Settings();

            var path = Path.Combine(defaultSettings.ScreenCapturePath, currentMethod);
            File.Delete(path);

            session.CaptureScreen();

            return path;
        }
    }
}