using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MobileClaimJobs.Controllers
{
    [Route("api/MobileJobsHealthCheck")]
    [ApiController]
    public class MobileJobsHealthCheckController : Controller
    {
        public ActionResult Working()
        {
            return Ok();
        }
    }
}
