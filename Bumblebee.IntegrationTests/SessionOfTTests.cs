using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Bumblebee.IntegrationTests.DriverEnvironments;
using Bumblebee.Setup;
using FluentAssertions;
using NUnit.Framework;

namespace Bumblebee.IntegrationTests
{
    [TestFixture]
    public class SessionOfTTests
    {
        [Test]
        public void given_same_thread_and_two_driver_environments_when_comparing_should_not_be_equal()
        {
            var ieSession = Session<IeEnvironment>.Current;
            var phantomSession = Session<PhantomEnvironment>.Current;

            ieSession.Should().NotBe(phantomSession);

            ieSession.End();
            phantomSession.End();
        }

        [Test]
        public void given_same_thread_and_same_driver_environments_when_comparing_should_be_equal()
        {
            var ieSession1 = Session<PhantomEnvironment>.Current;
            var ieSession2 = Session<PhantomEnvironment>.Current;

            ieSession1.Should().Be(ieSession2);

            ieSession1.End();
            ieSession2.End();
        }

        [Test]
        public void given_different_thread_and_same_driver_envrionments_when_comparing_should_not_be_equal()
        {
            var sessions = new ConcurrentDictionary<Guid, Session>();

            Action action = () =>
            {
                var session = Session<PhantomEnvironment>.Current;
                sessions.TryAdd(Guid.NewGuid(), session);
            };

            Parallel.Invoke(action, action);

            var session1 = sessions.ToArray()[0].Value;
            var session2 = sessions.ToArray()[1].Value;
            session1.Should().NotBe(session2);

            session1.End();
            session2.End();
        }

        [Test]
        public void given_instance_when_reseting_should_not_be_equal()
        {
            var ieSession1 = Session<PhantomEnvironment>.Current;
            Session<PhantomEnvironment>.Reset();

            var ieSession2 = Session<PhantomEnvironment>.Current;

            ieSession1.Should().NotBe(ieSession2);

            ieSession1.End();
            ieSession2.End();
        }
    }
}
