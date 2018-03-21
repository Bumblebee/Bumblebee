using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

using Bumblebee.Extensions;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.IntegrationTests.Shared.Pages.Implementation;
using Bumblebee.IntegrationTests.Shared.Sessions;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

using FluentAssertions;

using NUnit.Framework;

using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace Bumblebee.IntegrationTests.Setup
{
	//ReSharper disable InconsistentNaming

	[TestFixture]
	public class ThreadedSessionTests : HostTestFixture
    {
		[SetUp]
		public void BeforeEach()
		{
			Threaded<Session>.End();
			Threaded<DerivedSession>.End();
			Threaded<DerivedSessionWithWrongArgs>.End();
		}

		[Test]
		public void When_loading_with_driver_Then_should_return_session_with_correct_driver_with_default_settings()
		{
			Threaded<Session>
				.With(new PhantomJS())
				.Verify(x => x.Driver is PhantomJSDriver)
				.VerifyThat(x => x.Settings.ShouldBeEquivalentTo(new Settings()))
				.End();
		}

		[Test]
		public void When_loading_with_generic_driver_Then_should_return_session_with_correct_driver_with_default_settings()
		{
			Threaded<Session>
				.With<PhantomJS>()
				.Verify(x => x.Driver is PhantomJSDriver)
				.VerifyThat(x => x.Settings.ShouldBeEquivalentTo(new Settings()))
				.End();
		}

		[Test]
		public void When_loading_with_driver_and_custom_settings_Then_should_return_session_with_custom_settings()
		{
			var customSettings = new Settings
			{
				ScreenCapturePath = Environment.CurrentDirectory
			};

			Threaded<Session>
				.With(new PhantomJS(), customSettings)
				.VerifyThat(x => x.Settings.Should().Be(customSettings))
				.End();
		}

		[Test]
		public void When_loading_with_generic_driver_and_custom_settings_Then_should_return_session_with_custom_settings()
		{
			var customSettings = new Settings
			{
				ScreenCapturePath = Environment.CurrentDirectory
			};

			Threaded<Session>
				.With<PhantomJS>(customSettings)
				.VerifyThat(x => x.Settings.Should().Be(customSettings))
				.End();
		}

		[Test]
		public void Given_session_already_loaded_When_loading_with_another_driver_Then_should_end_previous_session_driver_and_return_session_with_correct_driver()
		{
			Session previousSession;

			Threaded<Session>
				.With<PhantomJS>()
				.Store(out previousSession, s => s)
				.Verify(x => x.Driver is PhantomJSDriver);

			Threaded<Session>
				.With<InternetExplorer>()
				.Verify(x => x.Driver is InternetExplorerDriver)
				.End();

			previousSession.Driver.Should().BeNull();
			previousSession.End();
		}

		[Test]
		public void Given_session_already_loaded_with_navigation_When_getting_matching_current_block_Then_should_return_block()
		{
		    Threaded<Session>
		        .With<PhantomJS>()
		        .NavigateTo<CheckboxPage>(GetUrl("Checkbox.html"));

		    Threaded<Session>
		        .CurrentBlock<CheckboxPage>()
		        .Verify(x => x.Session.Driver.PageSource.Contains("Unchecked"))
		        .Session.End();
        }

		[Test]
		public void Given_session_not_loaded_with_navigation_When_getting_current_block_Then_should_throw()
		{
			Action action = () =>
				Threaded<Session>
					.CurrentBlock<LoggedOutPage>()
					.Verify(x => x.Session.Driver.PageSource.Contains("Username or Email Address"))
					.Session.End();

			action
				.ShouldThrow<NullReferenceException>()
				.WithMessage("You cannot access the CurrentBlock without first initializing the Session by calling With<TDriverEnvironment>().");
		}

		[Test]
		public void Given_different_thread_and_same_driver_environments_When_comparing_Then_should_not_be_equal()
		{
			var sessions = new ConcurrentDictionary<Guid, Session>();

			Action action = () =>
			{
				var session = Threaded<Session>
					.With<PhantomJS>();
				sessions.TryAdd(Guid.NewGuid(), session);
			};

			var tasks = Enumerable
				.Repeat(0, 2)
				.Select(x => Task.Run(action));

			Task.WaitAll(tasks.ToArray());

			var session1 = sessions.ToArray()[0].Value;
			var session2 = sessions.ToArray()[1].Value;

			session1.Should().NotBe(session2);
			session1.Driver.Should().NotBeNull();
			session2.Driver.Should().NotBeNull();

			session1.End();
			session2.End();
		}

		[Test]
		public void Given_multiple_sessions_in_single_thread_When_loading_with_drivers_Then_should_maintain_distinct_sessions()
		{
			var session1 = Threaded<Session>
				.With<PhantomJS>()
				.Verify(s => s.Driver is PhantomJSDriver);

			var session2 = Threaded<DerivedSession>
				.With<PhantomJS>()
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
		public void Given_session_type_with_wrong_constructor_args_When_loading_with_driver_Then_should_throw()
		{
			Action action = () => Threaded<DerivedSessionWithWrongArgs>
				.With<PhantomJS>();

			var expectedMessage = String.Format(Threaded<DerivedSessionWithWrongArgs>.InvalidSessionTypeFormat, typeof(DerivedSessionWithWrongArgs));

			action
				.ShouldThrow<ArgumentException>()
				.WithMessage(expectedMessage);
		}

		[Test]
		public void Given_session_type_When_loading_with_driver_explicitly_Then_should_load_with_driver()
		{
			Threaded<Session>
				.With(new PhantomJS())
				.Verify(s => s.Driver is PhantomJSDriver)
				.End();
		}

		[Test]
		public void Given_session_has_not_been_loaded_with_driver_When_ending_Then_should_not_throw()
		{
			Action action = Threaded<Session>
				.End;

			action.ShouldNotThrow();
		}

		[Test]
		public void Given_session_has_been_loaded_with_driver_When_ending_THen_should_end_session()
		{
			Threaded<Session>
				.With<PhantomJS>();

			Threaded<Session>
				.End();
		}
	}
}
