using System;
using System.Collections.Generic;
using System.Threading;

namespace Bumblebee.Extensions
{
	public static class Debugging
	{
		public static T DebugPrint<T>(this T obj)
		{
			Console.WriteLine(obj.ToString());

			return obj;
		}

		public static T DebugPrint<T>(this T obj, string message)
		{
			Console.WriteLine(message);

			return obj;
		}

		public static T DebugPrint<T>(this T obj, Func<T, object> getObject)
		{
			Console.WriteLine(getObject(obj));

			return obj;
		}

		public static T DebugPrint<T>(this T obj, Func<T, IEnumerable<object>> getEnumerable)
		{
			getEnumerable(obj).Each(Console.WriteLine);

			return obj;
		}

		public static T DebugBreak<T>(this T obj)
		{
			if (System.Diagnostics.Debugger.IsAttached)
			{
				System.Diagnostics.Debugger.Break();
			}

			return obj;
		}

		public static T PlaySound<T>(this T obj, int pause = 0)
		{
			Console.WriteLine('\a');
			return obj.Pause(pause);
		}

		public static T Pause<T>(this T block, int miliseconds)
		{
			if (miliseconds > 0)
			{
				Thread.Sleep(miliseconds);
			}

			return block;
		}
	}
}
