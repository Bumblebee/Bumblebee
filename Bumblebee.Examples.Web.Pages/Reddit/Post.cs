using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Reddit
{
	public class Post : SpecificBlock
	{
		public Post(Session session, IWebElement tag) : base(session, tag)
		{
		}

		public IClickable<WebBlock> Title
		{
			get { return new Clickable<WebBlock>(this, By.CssSelector("a.title")); }
		}

		public IClickable<WebBlock> Author
		{
			get { return new Clickable<WebBlock>(this, By.ClassName("author")); }
		}

		public IClickable<WebBlock> Comments
		{
			get { return new Clickable<WebBlock>(this, By.ClassName("comments")); }
		}

		public IClickable<WebBlock> Domain
		{
			get { return new Clickable<WebBlock>(this, By.ClassName("domain")); }
		}

		public IClickable<RedditPage> Subreddit
		{
			get { return new Clickable<RedditPage>(this, By.ClassName("subreddit")); }
		}

		public string Rank
		{
			get { return FindElement(By.ClassName("rank")).Text; }
		}
	}
}
