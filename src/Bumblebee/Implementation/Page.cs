using System;

using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	/// <summary>
	/// The Page is an abstraction for representations of a page.
	/// </summary>
	/// <remarks>
	/// The Session.NavigateTo&lt;T&gt;() method is constrained to any types derived from this base since it assumes that the page should be scoped to the &lt;body&gt; tag.
	/// </remarks>
	public abstract class Page : Block, IPage
	{
		protected static readonly ISpecification By = null;

		/// <summary>
		/// Constructor that takes the Session for assembly of other composite elements and assumes that &lt;body&gt; tag is the scope for the page.
		/// </summary>
		/// <param name="session">The current session</param>
		/// <exception cref="ArgumentNullException">The session cannot be null.</exception>
		protected Page(Session session) : this(session, By.TagName("body"))
		{
		}

		/// <summary>
		/// Constructor that takes the Session and a By, to be used for testing purposes
		/// </summary>
		/// <param name="session">The current session.</param>
		/// <param name="by">The By specification, typically By.TagName("body")</param>
		internal Page(Session session, By @by) : base(session, @by)
		{
		}

		/// <summary>
		/// Allows for the creation of a derived Page based on a Session using reflection.
		/// </summary>
		/// <typeparam name="TPage"></typeparam>
		/// <param name="session"></param>
		/// <returns>The newly constructed Page object.</returns>
		public static TPage Create<TPage>(Session session) where TPage : IPage
		{
			return Block.Create<TPage>(session);
		}

		/// <summary>
		/// The tag that the page is scoped to.
		/// </summary>
		public override IWebElement Tag
		{
			get
			{
				return Session.Driver
					.SwitchTo()
					.DefaultContent()
					.FindElement(Specification);
			}
		}
	}
}
