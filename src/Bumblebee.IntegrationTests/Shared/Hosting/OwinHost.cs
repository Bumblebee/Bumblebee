using System;
using Microsoft.Owin.Hosting;


namespace Bumblebee.IntegrationTests.Shared.Hosting
{
    public class OwinHost : IHost
    {
        private IDisposable _server;
        private readonly Uri _baseUri;

        public OwinHost(Uri uri)
        {
            _baseUri = uri;
        }

        public void Dispose()
        {
            _server.Dispose();
        }

        public void Start()
        {
            _server = WebApp.Start<OwinStartUp>(url: _baseUri.OriginalString);
        }

        public void Stop()
        {
            Dispose();
        }
    }
}
