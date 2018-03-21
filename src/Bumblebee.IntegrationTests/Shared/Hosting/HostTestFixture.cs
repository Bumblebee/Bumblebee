using System;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Shared.Hosting
{
    [TestFixture]
    public abstract class HostTestFixture
    {
        protected virtual string GetUrl(string page)
        {
            return String.Format("{0}/Content/{1}", BaseUrl, page);
        }

        public static readonly string BaseUrl = "http://localhost:5000";
    }
}
