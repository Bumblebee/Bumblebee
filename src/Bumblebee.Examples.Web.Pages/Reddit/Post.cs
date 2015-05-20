using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Reddit
{
	public class Post : Block
	{
		public Post(IBlock parent, By @by) : base(parent, @by)
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
