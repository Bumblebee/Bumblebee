using System;

namespace Bumblebee.Setup
{
	/// <summary>
	/// A simple in-memory version of the <see cref="ISettings"/> interface.
	/// </summary>
	public class Settings : ISettings
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Settings"/> class.
		/// </summary>
		public Settings()
		{
			ScreenCapturePath = Environment.CurrentDirectory;
		}

		/// <summary>
		/// Gets or sets the screen capture output path.
		/// </summary>
		/// <value>
		/// The screen capture path.
		/// </value>
		public string ScreenCapturePath { get; set; }
	}
}