using System.Collections.Generic;
using System.Linq;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Reddit
{
    public class RedditPage : WebBlock
    {
        public RedditPage(Session session) : base(session)
        {}

        public IEnumerable<Post> Posts
        {
            get
            {
                return GetElements(By.CssSelector("#siteTable .link"))
                    .Select(tag => new Post(Session, tag));
            }
        }

        public IEnumerable<Post> RankedPosts
        {
            get { return Posts.Where(post => post.Rank != string.Empty); }
        }

        public IClickable<RedditPage> Next
        {
            get { return new Clickable<RedditPage>(this, By.PartialLinkText("next")); }
        }

        public IClickable<RedditPage> Prev
        {
            get { return new Clickable<RedditPage>(this, By.PartialLinkText("prev")); }
        }

        public IEnumerable<IClickable<RedditPage>> FeaturedSubreddits
        {
            get
            {
                return GetElements(By.CssSelector("#sr-bar a"))
                    .Where(a => a.Displayed)
                    .Select(a => new Clickable<RedditPage>(this, a));
            }
        }
    }
}
