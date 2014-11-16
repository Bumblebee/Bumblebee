using System.Collections.Generic;
using System.Linq;
using Bumblebee.Examples.Web.IntegrationTests.Infrastructure;
using Bumblebee.Examples.Web.Pages;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using FluentAssertions;
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
                .VerifyThat(page => 
                    page.Posts.Any(post =>
                    post.Subreddit.Text.Contains("todayilearned"))
                    .Should().BeTrue("there should be at least one til on the front page"))
                .VerifyThat(page => 
                    page.Posts.Any(post =>
                    post.Subreddit.Text.Contains("selenium"))
                    .Should().BeFalse("there should be no selenium subreddit posts on the front page"));
        }

        [Test]
        public void ShowPostsFromBooksSubreddit()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .FeaturedSubreddits.First(featured =>
                    featured.Text == "BOOKS")
                .Click()
                .DebugPrint(page =>
                    page.RankedPosts
                        .Select(post => post.Title.Text))
                .VerifyThat(page =>
                    page.RankedPosts
                        .First().Rank
                        .Should().Be("1", "the first page should start with a rank of 1"))
                .Next.Click()
                .VerifyThat(page =>
                    page.RankedPosts
                        .First().Rank
                        .Should().Be("26", "the second page should start with a rank of 26"));
        }
    }
}
