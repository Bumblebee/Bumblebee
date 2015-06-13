using System;
using System.Reflection;

namespace Bumblebee.Extensions
{
	public static class MethodBaseExtensions
	{
		public static string GetFullName(this MethodBase method)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}

			if (method.DeclaringType == null)
			{
				throw new ArgumentNullException("method.DeclaringType");
			}

			return String.Format("{0}.{1}", method.DeclaringType.FullName, method.Name);
		}
	}
}
