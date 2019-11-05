using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileClaimJobs.Interfaces;
using MobileClaimJobs.Models;
using MobileClaimJobs.Repositories;
using MongoDB.Driver;

namespace MobileClaimJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        // GET api/jobs
        [HttpGet]
        public string Get()

        {
            return "Mobile Claim Jobs Service!";
        }
    }
}