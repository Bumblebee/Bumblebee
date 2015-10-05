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
		/// Constructor takes the Session for assembly other composite elements and assumes that &lt;body&gt; tag is the scope for the page.
		/// </summary>
		/// <param name="session"></param>
		/// <exception cref="ArgumentNullException">The session cannot be null.</exception>
		protected Page(Session session) : base(session, By.TagName("body"))
		{
			if (session == null)
			{
				throw new ArgumentNullException("session");
			}
		}

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
