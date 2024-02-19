using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Bumblebee.IntegrationTests.Shared.Hosting;

public class TestSiteStartup
{
	public void ConfigureServices(IServiceCollection services) { }

	public void Configure(IApplicationBuilder app, IHostEnvironment env)
	{
		app.UseHsts();
		app.UseHttpsRedirection();

		app.UseStaticFiles(new StaticFileOptions
		{
			FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Content/"))
		});
	}
}