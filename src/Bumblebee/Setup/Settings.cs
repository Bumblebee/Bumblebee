using System;
using System.IO;

namespace Bumblebee.Setup
{
	/// <summary>
	/// A simple in-memory version of the <see cref="ISettings"/> interface.
	/// </summary>
	public class Settings : ISettings
	{
		private string _screenCapturePath;

		/// <summary>
		/// Initializes a default instance of the <see cref="Settings"/> class with <see cref="ScreenCapturePath"/> of the current directory.
		/// </summary>
		public Settings()
		{
			ScreenCapturePath = Environment.CurrentDirectory;
			CaptureScreenOnVerificationFailure = false;
		}

		/// <summary>
		/// Gets or sets the screen capture output path.
		/// </summary>
		/// <value>
		/// The screen capture path.
		/// </value>
		public string ScreenCapturePath
		{
			get { return _screenCapturePath; }
			set
			{
				if (Directory.Exists(value) == false)
				{
					throw new ArgumentException("Not an existing directory.", "value");
				}

				_screenCapturePath = value;
			}
		}

		public bool CaptureScreenOnVerificationFailure { get; set; }
	}
}
