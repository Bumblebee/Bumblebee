using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.DriverEnvironments;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.IntegrationTests.Shared.Sessions;
using Bumblebee.Setup;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace Bumblebee.IntegrationTests.Bumblebee.Setup
{
    [TestFixture]
    public class ThreadedSessionTests
    {
        [SetUp]
        public void BeforeEach()
        {
            Threaded<Session>.End();
            Threaded<DerivedSession>.End();
            Threaded<DerivedSessionWithWrongArgs>.End();
        }

        [Test]
        public void given_driver_environment_when_loading_with_driver_should_return_session_with_correct_driver()
        {
            Threaded<Session>
                .With<LocalPhantomEnvironment>()
                .Verify(x => x.Driver is PhantomJSDriver)
                .End();
        }

        [Test]
        public void given_session_already_loaded_when_loading_with_another_driver_should_end_previous_session_driver_and_return_session_with_correct_driver()
        {
            Session previousSession;

            Threaded<Session>
                .With<LocalPhantomEnvironment>()
                .Store(out previousSession, s => s)
                .Verify(x => x.Driver is PhantomJSDriver);

            Threaded<Session>
                .With<LocalIeEnvironment>()
                .Verify(x => x.Driver is InternetExplorerDriver)
                .End();

            previousSession.Driver.Should().BeNull();
            previousSession.End();
        }

        [Test]
        public void given_session_already_loaded_with_navigation_when_getting_matching_current_block_should_return_block()
        {
            Threaded<Session>
                .With<LocalPhantomEnvironment>()
                .NavigateTo<LoggedOutPage>("https://www.nirvanahq.com/account/login");

            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .Verify(x => x.Session.Driver.PageSource.Contains("Username or Email Address"))
                .Session.End();
        }

        [Test]
        public void given_session_not_loaded_with_navigation_when_getting_current_block_should_throw()
        {
            Action action = () =>
                Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .Verify(x => x.Session.Driver.PageSource.Contains("Username or Email Address"))
                .Session.End();

            action
                .ShouldThrow<NullReferenceException>()
                .WithMessage(
                    "You cannot access the CurrentBlock without first initializing the Session by calling With<TDriverEnvironment>().");
        }

        [Test]
        public void given_different_thread_and_same_driver_envrionments_when_comparing_should_not_be_equal()
        {
            var sessions = new ConcurrentDictionary<Guid, Session>();

            Action action = () =>
            {
                var session = Threaded<Session>
                    .With<LocalPhantomEnvironment>();
                sessions.TryAdd(Guid.NewGuid(), session);
            };

            var tasks = Enumerable.Repeat(0, 2)
                .Select(x => Task.Factory.StartNew(action));

            foreach (var task in tasks)
            {
                task.Wait();
            }

            var session1 = sessions.ToArray()[0].Value;
            var session2 = sessions.ToArray()[1].Value;

            session1.Should().NotBe(session2);
            session1.Driver.Should().NotBeNull();
            session2.Driver.Should().NotBeNull();

            session1.End();
            session2.End();
        }

        [Test]
        public void given_multiple_sessions_in_single_thread_when_loading_with_drivers_should_maintain_distinct_sessions()
        {
            var session1 = Threaded<Session>
                .With<LocalPhantomEnvironment>()
                .Verify(s => s.Driver is PhantomJSDriver);

            var session2 = Threaded<DerivedSession>
                .With<LocalPhantomEnvironment>()
                .Verify(s => s.Driver is PhantomJSDriver);

            session1
                .Verify(s => s is Session);

            session2
                .Verify(s => s is DerivedSession);

            session1.Should().NotBe(session2);

            session1.End();
            session2.End();
        }

        [Test]
        public void given_session_type_with_wrong_constructor_args_when_loading_with_driver_should_throw()
        {
            Action action = () => Threaded<DerivedSessionWithWrongArgs>
                .With<LocalPhantomEnvironment>();

            var expectedMessage =
                string.Format(
                    "The result type specified ({0}) is not a valid session.  It must have a constructor that takes only an IDriverEnvironment.",
                    typeof (DerivedSessionWithWrongArgs).FullName);

            action
                .ShouldThrow<ArgumentException>()
                .WithMessage(expectedMessage);
        }

        [Test]
        public void given_session_type_when_loading_with_driver_explicitly_should_load_with_driver()
        {
            Threaded<Session>
                .With(new LocalPhantomEnvironment())
                .Verify(s => s.Driver is PhantomJSDriver)
                .End();
        }

        [Test]
        public void given_session_has_not_been_loaded_with_driver_when_ending_should_not_throw()
        {
            Action action = Threaded<Session>
                .End;

            action.ShouldNotThrow();
        }

        [Test]
        public void given_session_has_been_loaded_with_driver_when_ending_should_end_session()
        {
            Threaded<Session>
                .With<LocalPhantomEnvironment>();

            Threaded<Session>
                .End();
        }
    }
}
