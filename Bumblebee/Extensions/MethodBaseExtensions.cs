using System;
using System.Reflection;

namespace Bumblebee.Extensions
{
	public static class MethodBaseExtensions
	{
		public static string GetFullName(this MethodBase methodInfo)
		{
			return String.Format("{0}.{1}", methodInfo.DeclaringType.FullName, methodInfo.Name);
		}
	}
}