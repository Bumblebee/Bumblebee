using System;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Shared.Hosting
{
	[TestFixture]
	public abstract class HostTestFixture
	{
		private IHost _host;

		protected HostTestFixture() : this("http://localhost:5000")
		{
		}

		protected HostTestFixture(string baseUrl)
		{
			BaseUrl = baseUrl;
		}

		[OneTimeSetUp]
		public void Init()
		{
			_host = new Host(new Uri(BaseUrl));
			_host.Start();
		}

		[OneTimeTearDown]
		public void Dispose()
		{
			_host.Stop();
		}

		protected virtual string GetUrl(string page)
		{
			return String.Format("{0}/Content/{1}", BaseUrl, page);
		}

		protected string BaseUrl { get; private set; }
	}
}
