using System;

using Bumblebee.IntegrationTests.Shared.Hosting;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests
{
	[SetUpFixture]
	public class AssemblyTestFixture
	{
		private static readonly Lazy<IHost> LazyHost = new Lazy<IHost>(() => new OwinHost(new Uri(HostTestFixture.BaseUrl)));
		private static IHost Host => LazyHost.Value;

		[OneTimeSetUp]
		public void Init()
		{
			Host.Start();
		}

		[OneTimeTearDown]
		public void Dispose()
		{
			Host.Stop();
		}
	}
}
