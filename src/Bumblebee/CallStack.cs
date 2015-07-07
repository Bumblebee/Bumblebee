using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Bumblebee
{
	internal static class CallStack
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MethodBase GetCurrentMethod()
		{
			var frame = new StackFrame(1, false);

			return frame.GetMethod();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MethodBase GetCallingMethod()
		{
			var frame = new StackFrame(2, false);

			return frame.GetMethod();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MethodBase GetConstructingMethod()
		{
			var trace = new StackTrace(false);

			if (trace.GetFrame(1).GetMethod().IsConstructor == false)
			{
				throw new ArgumentException("You may only call GetConstructingMethod from a Constructor.");
			}

			var frame = trace.GetFrames()
				.Skip(1)
				.FirstOrDefault(x => x.GetMethod().IsConstructor == false);

			return frame.GetMethod();
		}
	}
}