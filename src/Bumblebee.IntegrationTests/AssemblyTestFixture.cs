using System.IO;
using System.Threading.Tasks;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace Bumblebee.IntegrationTests
{
	[SetUpFixture]
	public class AssemblyTestFixture
	{
		private IWebHost _host = null!;
		public const string BaseUrl = "http://localhost:5000";

		[OneTimeSetUp]
		public void Init()
		{
			_host = WebHost.CreateDefaultBuilder()
						   .UseContentRoot(Path.Combine(Directory.GetCurrentDirectory(), "Content/"))
						   .UseUrls(BaseUrl)
						   .UseStartup<TestSiteStartup>()
						   .Build();

			_host.Start();
		}

		[OneTimeTearDown]
		public Task Dispose()
		{
			return _host.StopAsync();
		}
	}
}
