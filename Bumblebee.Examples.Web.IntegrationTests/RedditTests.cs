using System.Collections.Generic;
using System.Linq;
using Bumblebee.Examples.Web.IntegrationTests.Infrastructure;
using Bumblebee.Examples.Web.Pages;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.IntegrationTests
{
    [TestFixture]
    public class RedditTests
    {
        [SetUp]
        public void GoToReddit()
        {
            Threaded<Session>
                .With<LocalChromeEnvironment>()
                .NavigateTo<LoggedOutPage>("http://www.reddit.com");
        }

        [TearDown]
        public void TearDown()
        {
            Threaded<Session>
                .End();
        }

        [Test]
        public void Login()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .LoginArea
                .Email.EnterText("bumblebeeexample")
                .Password.EnterText("123abc!!")
                .LoginButton.Click()
                .VerifyPresenceOf("the logout link", By.CssSelector(".user a"));
        }

        [Test]
        public void FailLogin()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .LoginArea
                .Email.EnterText("jjjjjjj")
                .Password.EnterText("jjjjjjj")
                .LoginButton.Click<LoggedOutPage>()
                .VerifyPresenceOf("the login area", By.Id("login_login-main"));
        }

        [Test]
        public void VerifyObviousThings()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .Verify("that there is at least one TIL on front page",
                    page => page.Posts.Any(post => post.Subreddit.Text.Contains("todayilearned")))
                .Verify("there are no selenium subreddit posts on front page",
                    page => page.Posts.All(post => !post.Subreddit.Text.Contains("selenium")));
        }

        [Test]
        public void ShowPostsFromBooksSubreddit()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .FeaturedSubreddits.First(featured => featured.Text == "BOOKS").Click()
                .DebugPrint(page => page.RankedPosts.Select(post => post.Title.Text))
                .Verify("that first page starts with rank of 1", page => page.RankedPosts.First().Rank == "1")
                .Next.Click()
                .Verify("that second page starts with rank of 26", page => page.RankedPosts.First().Rank == "26");
        }
    }
}
