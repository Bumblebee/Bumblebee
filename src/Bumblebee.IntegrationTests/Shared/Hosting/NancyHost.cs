using System;

using Nancy.Hosting.Self;

namespace Bumblebee.IntegrationTests.Shared.Hosting
{
	public class NancyHost : IHost
	{
		private readonly Nancy.Hosting.Self.NancyHost _host;

		public NancyHost(Uri baseUri)
		{
			var config = new HostConfiguration {UrlReservations = {CreateAutomatically = true}};
            _host = new Nancy.Hosting.Self.NancyHost(config, baseUri);
		}

		public void Start()
		{
			_host.Start();
		}

		public void Stop()
		{
			_host.Stop();
		}

		~NancyHost()
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
