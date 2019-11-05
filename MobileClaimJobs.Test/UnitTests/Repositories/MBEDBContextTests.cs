using AutoFixture;
using MobileClaimJobs.Models;
using MobileClaimJobs.Repositories;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MobileClaimJobs.Test.UnitTests.Repositories
{
    public class MBEDBContextTests : IDisposable
    {
        #region Private members
        private MBEDBContext _sut;
        private Fixture _fixture;
        private const string MBE_DB_NAME = "database-name";
        private const string MBE_DB_URL = "mongodb://mongo-url/mbedb";
        #endregion

        public MBEDBContextTests()
        {
            Environment.SetEnvironmentVariable("MBE_DB_URL", MBE_DB_URL);
            Environment.SetEnvironmentVariable("MBE_DB_NAME", MBE_DB_NAME);
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "development");
            _fixture = new Fixture();
            _sut = new MBEDBContext();
        }

        #region GetCollection
        [Fact]
        public void GetCollection_Returns_Collection()
        {
            // Arrange
            // Act
            var result1 = _sut.GetClaims<BsonDocument>();
            var result2 = _sut.GetClaims<Claim>();
            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
        }
        #endregion

        #region Data Builders

        #endregion

        public void Dispose()
        {
            if (_sut != null)
            {
                //_sut.Dispose();
            }
        }
    }
}
