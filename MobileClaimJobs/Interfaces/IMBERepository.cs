using MobileClaimJobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileClaimJobs.Interfaces
{
    public interface IMBERepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matchedClaims"></param>
        /// <param name="estimatePhotoStatus"></param>
        /// <returns></returns>
        Task UpdateClaimsStatuses(List<Claim> matchedClaims, int estimatePhotoStatus);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Claim>> GetEligibleEstimateStatusClaims();
    }
}
