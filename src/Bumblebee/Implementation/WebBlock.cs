using System;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	/// <summary>
	/// Base block for typical web pages allowing for specifying a common wait timeout for finding elements.
	/// </summary>
	[Obsolete("Use Block now for scoped sections of a page or use Page to represent the page.", error: true)]
	public abstract class WebBlock : Block
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <remarks>
		/// The default timeout for waiting for elements is 3000 ticks (3-100 nano seconds).  If you need to override this value, call the other constructor.
		/// </remarks>
		/// <param name="parent">The parent.</param>
		/// <param name="by">The by.</param>
		protected WebBlock(IBlock parent, By @by) : this(parent, @by, TimeSpan.FromTicks(3000))
		{
		}

		/// <summary>
		/// Constructor that allows for overriding the default timeout for waits.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="by">The by.</param>
		/// <param name="timeout">The timeout period for waits represented as a TimeSpan</param>
		protected WebBlock(IBlock parent, By @by, TimeSpan timeout)
			: base(parent, @by)
		{
		}

		/// <summary>
		/// The actual web element that the Block is abstracting.
		/// </summary>
		public override IWebElement Tag
		{
			get { return Wait.Until(driver => base.Tag); }
		}
	}
}
