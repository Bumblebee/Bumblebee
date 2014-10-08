using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.TestSupport.Sessions
{
    public class DerivedSession : Session
    {
        public DerivedSession(IDriverEnvironment environment)
            : base(environment)
        {}
    }
}
