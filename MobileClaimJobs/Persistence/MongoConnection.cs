using Microsoft.Extensions.Configuration;
using MobileClaimJobs.Configurations;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileClaimJobs.Persistence
{
    public interface IMongoConnection
    {
        string Owner { get; set; }

        IMongoCollection<T> GetCollection<T>();
    }

    public class MongoConnection : IMongoConnection
    {
        protected readonly IMongoDatabase Database;

        public string Owner { get; set; }

        public MongoConnection()
        {
            MongoDefaults.GuidRepresentation = GuidRepresentation.Standard;
            var mongoUrl = new MongoUrl(Environment.GetEnvironmentVariable("MBE_DB_URL"));
            Database = new MongoClient(mongoUrl).GetDatabase(mongoUrl.AuthenticationSource);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            var name = typeof(T).Name;
            if (name.EndsWith("DAO"))
            {
                name = name.Substring(0, name.Length - 3);
            }

            return Database.GetCollection<T>(name);
        }
    }
}

