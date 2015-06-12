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
		public static string GetCurrentMethodFullName(this object value)
		{
			var sf = new StackFrame(1, false);
			return sf.GetMethod().GetFullName();
		}

		/// <summary>
		/// Gets the parent method name including namespace and declaring type.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetParentMethodFullName(this object value)
		{
			var sf = new StackFrame(2, false);
			return sf.GetMethod().GetFullName();
		}
	}
}