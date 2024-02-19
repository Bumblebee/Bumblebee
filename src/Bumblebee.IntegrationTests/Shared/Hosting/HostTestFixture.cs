using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Shared.Hosting
{
	[TestFixture]
	public abstract class HostTestFixture
	{
		protected virtual string GetUrl(string page) => $"{AssemblyTestFixture.BaseUrl}/{page}";
	}
}
