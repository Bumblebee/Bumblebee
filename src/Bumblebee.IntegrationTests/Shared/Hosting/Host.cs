using System;

using Nancy.Hosting.Self;

namespace Bumblebee.IntegrationTests.Shared.Hosting
{
	public class Host : IHost
	{
		private readonly NancyHost _host;

		public Host(Uri baseUri)
		{
			_host = new NancyHost(baseUri);
		}

		public void Start()
		{
			_host.Start();
		}

		public void Stop()
		{
			_host.Stop();
		}

		~Host()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose managed resources

				_host.Stop();

				_host.Dispose();
			}

			// dispose native resources
		}
	}
}
