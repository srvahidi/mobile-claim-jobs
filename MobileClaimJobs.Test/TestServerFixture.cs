using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MobileClaimJobs.Test
{
    public abstract class TestServerFixture : IDisposable
    {
        protected HttpClient Client;

        public TestServerFixture()
        {
            Client = new HttpClient();
        }
        public virtual void Dispose()
        {
            Client?.Dispose();
        }
    }
}
