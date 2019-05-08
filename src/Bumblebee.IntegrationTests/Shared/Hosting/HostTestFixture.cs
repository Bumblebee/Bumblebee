using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Shared.Hosting
{
	[TestFixture]
	public abstract class HostTestFixture
	{
		protected virtual string GetUrl(string page)
		{
			return $"{BaseUrl}/Content/{page}";
		}

		public static readonly string BaseUrl = "http://localhost:5000"; 
	}
}
