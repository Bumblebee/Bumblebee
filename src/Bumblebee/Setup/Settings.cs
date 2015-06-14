using System;
using System.IO;

namespace Bumblebee.Setup
{
	/// <summary>
	/// A simple in-memory version of the <see cref="ISettings"/> interface.
	/// </summary>
	public class Settings : ISettings
	{
		/// <summary>
		/// Initializes a default instance of the <see cref="Settings"/> class with <see cref="ScreenCapturePath"/> of the current directory.
		/// </summary>
		public Settings() : this(Environment.CurrentDirectory)
		{
		}

		/// <summary>
		/// Initializes an instance of the <see cref="Settings"/> class with <see cref="ScreenCapturePath"/> of the <see cref="path"/>.
		/// </summary>
		/// <param name="path">The path to use for screenshots.</param>
		public Settings(string path)
		{
			if (Directory.Exists(path) == false)
			{
				throw new ArgumentException("Not an existing directory.", "path");
			}

			ScreenCapturePath = path;
		}

		/// <summary>
		/// Gets or sets the screen capture output path.
		/// </summary>
		/// <value>
		/// The screen capture path.
		/// </value>
		public string ScreenCapturePath { get; private set; }
	}
}
