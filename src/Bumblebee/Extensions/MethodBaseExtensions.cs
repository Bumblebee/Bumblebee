using System;
using System.Reflection;

namespace Bumblebee.Extensions
{
	public static class MethodBaseExtensions
	{
		public static string GetFullName(this MethodBase methodInfo)
		{
			if (methodInfo == null)
			{
				throw new ArgumentNullException("methodInfo");
			}

			if (methodInfo.DeclaringType == null)
			{
				// this only happens for C++/CLI defined global free functions (e.g. basically never)
				throw new ArgumentNullException("methodInfo.DeclaringType");
			}

			return String.Format("{0}.{1}", methodInfo.DeclaringType.FullName, methodInfo.Name);
		}
	}
}
