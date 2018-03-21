using System;
using Bumblebee.IntegrationTests.Shared.Hosting;
using NUnit.Framework;

namespace Bumblebee.IntegrationTests
{
    [SetUpFixture]
    public class AssemblyTestFixture
    {
        private static readonly Lazy<IHost> Host = new Lazy<IHost>(() => new OwinHost(new Uri(HostTestFixture.BaseUrl)));

        [OneTimeSetUp]
        public void Init()
        {
            Host.Value.Start();
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            Host.Value.Stop();
        }
    }
}
