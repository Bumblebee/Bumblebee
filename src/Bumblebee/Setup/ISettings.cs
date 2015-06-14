namespace Bumblebee.Setup
{
	/// <summary>
	/// An interface to specify the settings that are useful to the Session.
	/// </summary>
	public interface ISettings
	{
		/// <summary>
		/// Gets or sets the screen capture output path.
		/// </summary>
		/// <value>
		/// The screen capture path.
		/// </value>
		string ScreenCapturePath { get; }
	}
}
