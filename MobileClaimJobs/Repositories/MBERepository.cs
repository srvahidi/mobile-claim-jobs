using MobileClaimJobs.Interfaces;
using MobileClaimJobs.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileClaimJobs.Repositories
{
    public class MBERepository : IMBERepository
    {
        #region Private members
        private readonly MBEDBContext _MBEDBContext;
        private readonly int EstimatePhotoStatus;
        private readonly int RetrospectiveDays;
        private readonly int HoursToWaitBeforeStatusUpdate;


        #endregion

        public MBERepository(MBEDBContext pMBEDBContext)
        {
            _MBEDBContext = pMBEDBContext;
            EstimatePhotoStatus = 12;
            RetrospectiveDays = Int32.Parse(Environment.GetEnvironmentVariable("RETRO_DAYS"));
            HoursToWaitBeforeStatusUpdate = Int32.Parse(Environment.GetEnvironmentVariable("HOURS_TO_WAIT_BEFORE_UPDATE"));
        }

        public async Task<List<Claim>> GetEligibleEstimateStatusClaims()
        {
            DateTime endDate = DateTime.Now;

            DateTime startDate = endDate.AddDays(-RetrospectiveDays);
            IMongoCollection<Claim> claimsCollection = _MBEDBContext.GetClaims<Claim>();
            var filter = Builders<Claim>.Filter.Where(itm => itm.createdDate <= endDate && itm.createdDate >= startDate && itm.customerStatus == EstimatePhotoStatus && itm.updatedDate < DateTime.Now.AddHours(-HoursToWaitBeforeStatusUpdate));

            List<Claim> selectedClaims = await claimsCollection.Find(filter).ToListAsync<Claim>();
            Console.WriteLine("Fetched the ClaimsList");
            return selectedClaims;
        }

        public async Task UpdateClaimsStatuses(List<Claim> matchedClaims, int targetStatus)
        {
            foreach (Claim claim in matchedClaims)
            {
                IMongoCollection<Claim> claimsCollection = _MBEDBContext.GetClaims<Claim>();
                var filter = Builders<Claim>.Filter.Where(itm => itm.Id == claim.Id);
                var updateSet = Builders<Claim>.Update.Set("customerStatus", targetStatus).Set("updatedDate", DateTime.Now);
                var updateResult = await claimsCollection.UpdateOneAsync(filter, updateSet);
                Console.WriteLine($"Status updated for the claim # : {claim.claimNumber}");
            }
            return;
        }
    }
}


