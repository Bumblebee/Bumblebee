using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Sessions
{
	public class DerivedSession : Session
	{
		public DerivedSession(IDriverEnvironment environment) : base(environment)
		{
		}
	}
}
