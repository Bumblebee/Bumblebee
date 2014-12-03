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
    }
}
