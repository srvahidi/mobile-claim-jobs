using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileClaimJobs.Repositories
{
    public class MBEDBContext
    {
        #region Private members
        private IMongoDatabase database;
        private readonly string environment;
        #endregion

        public MBEDBContext()
        {
            var _dbUrl = Environment.GetEnvironmentVariable("MBE_DB_URL");
            var _dbName = Environment.GetEnvironmentVariable("MBE_DB_NAME");
            environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine("Getting the mongo Client");
            var client = new MongoClient(_dbUrl);
            Console.WriteLine($"Getting database name...{_dbName}");
            database = client.GetDatabase(_dbName);
        }
        public virtual IMongoCollection<T> GetClaims<T>()
        {
            Console.WriteLine($"Getting collection name...Claims");
            IMongoCollection<T> collection = database.GetCollection<T>("Claims");
            return collection;
        }
    }
}
