using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MobileClaimJobs.Test.UnitTests
{
    public class ControllerTests : TestServerFixture
    {
        [Fact]
        public async Task<string>  HealthCheck__Should_ReturnOK()
        {
            var response = await Client.GetAsync("api/mobilejobshealthcheck");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
