using System;
using System.IO;
using System.Linq;

using Bumblebee.Extensions;
using Bumblebee.Setup;

using FluentAssertions;

using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Setup.SessionTests
{
	[TestFixture]
	public class Given_default_implementation_of_ISettings
	{
		[Test]
		public void When_default_constructor_is_used_Then_current_directory_is_used()
		{
			var settings = new Settings();

			settings.ScreenCapturePath.Should().Be(Environment.CurrentDirectory);
		}

		[Test]
		public void When_path_points_to_a_valid_directory_in_Then_an_exception_is_not_thrown()
		{
			var drive = Path.GetPathRoot(Environment.CurrentDirectory);

			var directory = Directory.GetDirectories(drive)
				.Shuffle()
				.FirstOrDefault();

			Action fn = () => new Settings
			{
				ScreenCapturePath = directory
			};

			fn.ShouldNotThrow<ArgumentException>();
		}

		[Test]
		public void When_path_points_to_a_directory_that_does_not_exist_Then_an_exception_is_thrown()
		{
			var drive = Path.GetPathRoot(Environment.CurrentDirectory);

			var directoryname = String.Format("{0}", Guid.NewGuid());

			var directory = Path.Combine(drive, directoryname);

			Action fn = () => new Settings
			{
				ScreenCapturePath = directory
			};

			fn.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void When_path_points_to_a_file_Then_an_exception_is_thrown()
		{
			var drive = Path.GetPathRoot(Environment.CurrentDirectory);

			var filename = Path.Combine(drive, String.Format("{0}.txt", Guid.NewGuid()));

			File.Delete(filename);

			File.WriteAllText(filename, "Hello, World.");

			Action fn = () => new Settings
			{
				ScreenCapturePath = filename
			};

			fn.ShouldThrow<ArgumentException>();

			File.Delete(filename);
		}
	}
}
