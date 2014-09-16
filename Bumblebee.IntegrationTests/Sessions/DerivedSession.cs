using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Sessions
{
    public class DerivedSession : Session
    {
        public DerivedSession(IDriverEnvironment environment)
            : base(environment)
        {}
    }
}
