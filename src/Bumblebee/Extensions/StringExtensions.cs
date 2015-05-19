namespace Bumblebee.Extensions
{
	/// <summary>
	/// Extensions for the string data type.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Formats the string with the specified arguments.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="args">The arguments.</param>
		/// <returns></returns>
		public static string FormatWith(this string value, params object[] args)
		{
			return string.Format(value, args);
		}
	}
}
