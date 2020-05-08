using MobileClaimJobs.Interfaces;
using MobileClaimJobs.Models;
using MobileClaimJobs.Persistence;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        private readonly IMongoConnection _mongoConnection;
        private readonly IHttpPort _httpPort;

        #endregion

        public MBERepository(MBEDBContext pMBEDBContext, IMongoConnection mongoConnection, IHttpPort httpPort)
        {
            _MBEDBContext = pMBEDBContext;
            EstimatePhotoStatus = 12;
            _mongoConnection = mongoConnection;
            _httpPort = httpPort;
            RetrospectiveDays = Int32.Parse(Environment.GetEnvironmentVariable("RETRO_DAYS"));
            HoursToWaitBeforeStatusUpdate = Int32.Parse(Environment.GetEnvironmentVariable("HOURS_TO_WAIT_BEFORE_UPDATE"));
        }

        public async Task<List<Claims>> GetEligibleEstimateStatusClaims()
        {
            DateTime endDate = DateTime.Now;

            DateTime startDate = endDate.AddDays(-RetrospectiveDays);

            IMongoCollection<Claims> claimsCollection = _mongoConnection.GetCollection<Claims>();
            var filter = Builders<Claims>.Filter.Where(itm => itm.createdDate <= endDate && itm.createdDate >= startDate && itm.customerStatus == EstimatePhotoStatus && itm.updatedDate < DateTime.Now.AddHours(-HoursToWaitBeforeStatusUpdate));

            List<Claims> selectedClaims = await claimsCollection.Find(filter).ToListAsync<Claims>();
            Console.WriteLine("Fetched the ClaimsList");
            return selectedClaims;
        }

        public async Task UpdateClaimsStatuses(List<Claims> matchedClaims, int targetStatus)
        {
            string MBEWrapperUrl = Environment.GetEnvironmentVariable("MBE_WRAPPER_URL");
            string apiKey = Environment.GetEnvironmentVariable("MBE_WRAPPER_API_KEY");

            foreach (Claims claim in matchedClaims)
            {
                string claimPutUrl = MBEWrapperUrl + "api/claim/" + claim.Id + "/update?apiKey=" + apiKey;

                Console.WriteLine($":UPDATE CLAIM : Update claim request sent to MBE using URL   : [ {claimPutUrl} ]");
                ClaimUpdateData updateData = new ClaimUpdateData
                {
                    CustomerStatus = targetStatus
                };

                string jsonData = JsonConvert.SerializeObject(updateData);
                var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage claimPutResponse = await _httpPort.PutAsync(new Uri(claimPutUrl), jsonContent);
            }
            return;
        }
    }
}


