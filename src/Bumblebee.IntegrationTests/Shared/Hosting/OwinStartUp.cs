using System;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace Bumblebee.IntegrationTests.Shared.Hosting
{
    public class OwinStartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var root = AppDomain.CurrentDomain.BaseDirectory;

            var fileServerOptions = new FileServerOptions
            {
                RequestPath = PathString.Empty,
                EnableDefaultFiles = true,
                FileSystem = new PhysicalFileSystem(root),
                EnableDirectoryBrowsing = true
            };

            fileServerOptions.StaticFileOptions.ServeUnknownFileTypes = false;
            app.UseFileServer(fileServerOptions);
        }
    }
}