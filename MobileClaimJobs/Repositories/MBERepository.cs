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
        #endregion

        public MBERepository(MBEDBContext pMBEDBContext)
        {
            _MBEDBContext = pMBEDBContext;
            EstimatePhotoStatus = 12;
        }

        public async Task<List<Claim>> GetEligibleEstimateStatusClaims()
        {
            try
            {
                //DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime endDate = DateTime.Now;

                DateTime startDate = endDate.AddDays(-7);

                IMongoCollection<Claim> claimsCollection = _MBEDBContext.GetClaims<Claim>();
                var filter = Builders<Claim>.Filter.Where(itm => itm.createdDate <= endDate && itm.createdDate >= startDate && itm.customerStatus == EstimatePhotoStatus && itm.updatedDate < DateTime.Now.AddHours(-6));
                List<Claim> selectedClaims = await claimsCollection.Find(filter).ToListAsync<Claim>();
                Console.WriteLine("Fetched the ClaimsList");
                return selectedClaims;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The message is {ex.Message}");
                return null;
            }
        }

        public async Task UpdateClaimsStatuses(List<Claim> matchedClaims, int targetStatus)
        {
            foreach (Claim claim in matchedClaims)
            {
                IMongoCollection<Claim> claimsCollection = _MBEDBContext.GetClaims<Claim>();
                var filter = Builders<Claim>.Filter.Where(itm => itm.Id == claim.Id);
                var updateSet = Builders<Claim>.Update.Set("customerStatus", targetStatus);
                var updoneresult = await claimsCollection.UpdateOneAsync(filter, updateSet);
            }
            return;
        }

    }
}


