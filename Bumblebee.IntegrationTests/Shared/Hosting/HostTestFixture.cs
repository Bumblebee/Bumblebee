using System;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Shared.Hosting
{
	[TestFixture]
	public abstract class HostTestFixture
	{
		private IHost _host;

		protected HostTestFixture() : this("http://localhost:1234")
		{
		}

		protected HostTestFixture(string baseUrl)
		{
			BaseUrl = baseUrl;
		}

		[TestFixtureSetUp]
		public void Init()
		{
			_host = new Host(new Uri(BaseUrl));
			_host.Start();
		}

		[TestFixtureTearDown]
		public void Dispose()
		{
			_host.Stop();
		}

		protected string BaseUrl { get; private set; }
	}
}
