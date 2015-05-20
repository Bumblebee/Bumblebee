using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Bumblebee.Extensions
{
	/// <summary>
	/// Set of extensions for the Object type.
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Gets the current method name including namespace and declaring type.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetCurrentMethodName(this object value)
		{
			var st = new StackTrace();
			var sf = st.GetFrame(1);

			return sf.GetMethod().GetFullName();
		}

		/// <summary>
		/// Gets the parent method name including namespace and declaring type.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetParentMethodName(this object value)
		{
			var st = new StackTrace();
			var sf = st.GetFrame(2);

			return sf.GetMethod().GetFullName();
		}
	}
}