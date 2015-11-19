using System;
using System.Collections.ObjectModel;
using System.Linq;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Specifications
{
	public static class ByExtensions
	{
		public static By WaitingUntil(this By @by, TimeSpan timeout)
		{
			return new ByWithWait(@by, timeout);
		}
	}

	/// <summary>
	/// Wrapper class that accepts a By selector and a timeout period expressed in a TimeSpan.  WHen FindElement or FindElements are called, it uses the WebDriverWait functionality to select.
	/// </summary>
	public class ByWithWait : By
	{
		private readonly By _by;
		private readonly TimeSpan _timeout;

		/// <summary>
		/// Initializes a new instance of the <see cref="ByWithWait"/> class.
		/// </summary>
		/// <param name="by">The by.</param>
		/// <param name="timeout">The timeout.</param>
		public ByWithWait(By @by, TimeSpan timeout)
		{
			_by = @by;
			_timeout = timeout;
		}

		/// <summary>
		/// Finds the first element matching the criteria.
		/// </summary>
		/// <param name="context">An <see cref="T:OpenQA.Selenium.ISearchContext" /> object to use to search for the elements.</param>
		/// <returns>
		/// The first matching <see cref="T:OpenQA.Selenium.IWebElement" /> on the current context.
		/// </returns>
		public override IWebElement FindElement(ISearchContext context)
		{
			var elements = FindElements(context);

			if (elements.Any() == false)
			{
				throw new NotFoundException(String.Format("Unable to find element {0}", _by));
			}

			return elements.First();
		}

		/// <summary>
		/// Finds all elements matching the criteria.
		/// </summary>
		/// <param name="context">An <see cref="T:OpenQA.Selenium.ISearchContext" /> object to use to search for the elements.</param>
		/// <returns>
		/// A <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> of all <see cref="T:OpenQA.Selenium.IWebElement">WebElements</see>
		/// matching the current criteria, or an empty list if nothing matches.
		/// </returns>
		public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
		{
			var wait = new DefaultWait<ISearchContext>(context)
			{
				Timeout = _timeout
			};

			var result = wait.Until(x =>
			{
				var results = x.FindElements(_by);
				return results.Count > 0 ? results : null;
			});

			return new ReadOnlyCollection<IWebElement>(result.ToList());
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}