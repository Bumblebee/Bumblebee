using System;

using Bumblebee.Extensions;
using Bumblebee.Setup;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Implementation
{
	/// <summary>
	/// Base block for typical web pages allowing for specifying a common wait timeout for finding elements.
	/// </summary>
	public abstract class WebBlock : Block
	{
		/// <summary>
		/// A common wait timeout that can be used when trying to find elements within derived pages or blocks.
		/// </summary>
		protected WebDriverWait Wait { get; private set; }

		public override IWebElement Tag
		{
			get
			{
				return Wait.Until(driver => base.Tag); // TODO: this feels....wonky
			}
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <remarks>
		/// The default timeout for waiting for elements is 3000 ticks (3-100 nano seconds).  If you need to override this value, call the other constructor.
		/// </remarks>
		/// <param name="session">The sessionto be used for finding elements in the derived page.</param>
		protected WebBlock(Session session) : this(session, TimeSpan.FromTicks(3000))
		{
		}

		/// <summary>
		/// Constructor that allows for overriding the default timeout for waits.
		/// </summary>
		/// <param name="session">The session to be used for finding elements in the derived page.</param>
		/// <param name="timeout">The timeout period for waits represented as a TimeSpan</param>
		protected WebBlock(Session session, TimeSpan timeout) : base(session, By.TagName("body"))
		{
			this.Pause(200);
			Wait = new WebDriverWait(Session.Driver, timeout);
		}
	}
}
