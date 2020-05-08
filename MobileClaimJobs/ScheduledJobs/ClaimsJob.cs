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
            try
            {
                Console.WriteLine("The job execution started!");
                List<Claims> matchedClaims = await _MBERepository.GetEligibleEstimateStatusClaims();
                if (matchedClaims != null && matchedClaims.Count != 0)
                {
                    await _MBERepository.UpdateClaimsStatuses(matchedClaims, ClaimSubmissionStatus);
                    Console.WriteLine($"Updated status to 5 for {matchedClaims.Count} claim(s)");
                }
                else
                {
                    Console.WriteLine("No claims exist with customer status 12 or not eligible for the customer status update");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The job execution error message is {ex.Message}");
            }
            return;
        }
    }
}
