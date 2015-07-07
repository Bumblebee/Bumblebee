namespace Bumblebee.Setup
{
	/// <summary>
	/// An interface to specify the settings that are useful to the Session.
	/// </summary>
	public interface ISettings
	{
		/// <summary>
		/// Gets the screen capture output path.
		/// </summary>
		/// <value>
		/// The screen capture path.
		/// </value>
		string ScreenCapturePath { get; }

		/// <summary>
		/// Gets whether or not to implicitly capture screenshots on a verification failure.
		/// </summary>
		bool CaptureScreenOnVerificationFailure { get; }
	}
}
