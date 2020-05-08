using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileClaimJobs.Interfaces
{
    public interface IHttpPort
    {
        Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content);
    }
}
