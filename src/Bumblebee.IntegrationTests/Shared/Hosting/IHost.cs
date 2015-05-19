using System;

namespace Bumblebee.IntegrationTests.Shared.Hosting
{
	public interface IHost : IDisposable
	{
		void Start();
		void Stop();
	}
}
