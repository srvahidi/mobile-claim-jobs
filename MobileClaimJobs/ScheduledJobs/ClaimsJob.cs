using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileClaimJobs.Interfaces;
using MobileClaimJobs.Models;
using Quartz;

namespace MobileClaimJobs.ScheduledJobs
{
    public class ClaimsJob : IJob
    {
        private readonly IMBERepository _MBERepository;
        private readonly int ClaimSubmissionStatus;
        public ClaimsJob(IMBERepository MBERepository)
        {
            _MBERepository = MBERepository;
            ClaimSubmissionStatus = 5;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("The job has been executed!");
            List<Claim> matchedClaims = await _MBERepository.GetEligibleEstimateStatusClaims();
            await _MBERepository.UpdateClaimsStatuses(matchedClaims, ClaimSubmissionStatus);
            return;
        }
    }
}
