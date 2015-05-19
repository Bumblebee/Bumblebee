using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Sessions
{
	public class DerivedSessionWithWrongArgs : Session
	{
		public DerivedSessionWithWrongArgs(IDriverEnvironment environment, IMonkey monkey) : base(environment)
		{
			Monkey = monkey;
		}
	}
}
