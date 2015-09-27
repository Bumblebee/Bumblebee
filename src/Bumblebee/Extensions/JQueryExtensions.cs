using Bumblebee.Setup;

namespace Bumblebee.Extensions
{
	public static class JQueryExtensions
	{
		/// <summary>
		/// This method is for determining if a Session has access to jQuery.
		/// </summary>
		/// <param name="session">The Session in question.</param>
		/// <returns>True if the current frame/page context has jQuery.</returns>
		public static bool HasJQuery(this Session session)
		{
			// given the way the JavaScript is executed, using the simple variable name 'jQuery' here throws an InvalidOperationException
			// this can be reproduced in the browser (tested in Chrome) by running "new Function('return !!jQuery;')()" in the developer console
			// on a page that does not have a jQuery variable defined

			return session.ExecuteJavaScript<bool>(@"return !!window[""jQuery""];");
		}
	}
}
