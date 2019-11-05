using AutoFixture;
using MobileClaimJobs.Models;
using MobileClaimJobs.Repositories;
using MobileClaimJobs.Test.TestUtilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace MobileClaimJobs.Test.UnitTests.Repositories
{
    public class MBERepositoryTests : IDisposable
    {
        #region Private members
        private MBERepository _sut;
        private Mock<MBEDBContext> _mockMBEDBContext;
        private Mock<IMongoCollection<Claim>> _mockMongoCollection;
        private const string MBE_DB_URL = "mongodb://mongo-url/mbedb";
        private const string MBE_DB_NAME = "mbe";
        private Fixture _fixture;
        #endregion

        public MBERepositoryTests()
        {
            _fixture = new Fixture();
            Environment.SetEnvironmentVariable("MBE_DB_URL", MBE_DB_URL);
            Environment.SetEnvironmentVariable("MBE_DB_NAME", MBE_DB_NAME);
            _mockMBEDBContext = new Mock<MBEDBContext>();
            _mockMongoCollection = new Mock<IMongoCollection<Claim>>();
            _mockMBEDBContext.Setup(m => m.GetClaims<Claim>())
                .Returns(_mockMongoCollection.Object).Verifiable();
            _sut = new MBERepository(_mockMBEDBContext.Object);
        }

        #region StoreValuation
        //[Fact]
        //public async void UpdateClaimsStatuses_Should_ThrowArgumentNullException_When_NullRequest()
        //{
        //    // Arrange        
        //    // Act
        //    var result = await Assert.ThrowsAsync<ArgumentNullException>(() =>
        //        _sut.UpdateClaimsStatuses(null, 0)
        //    );
        //    // Assert
        //    _mockMBEDBContext.Verify(m => m.GetClaims<Claim>(), Times.Never);
        //    Assert.NotNull(result);
        //    Assert.IsType<ArgumentNullException>(result);
        //    Assert.Contains("Cannot be null", result.Message);
        //}
        //[Fact]
        //public async void UpdateClaimsStatuses_Should_UpdateClaim()
        //{
        //    // Arrange
        //    var MBEClaim = _fixture.Create<List<Claim>>();
        //    Claim claimToUpdate = null;
        //    var mockCursor = new Mock<IAsyncCursor<Claim>>();
        //    mockCursor.Setup(m => m.MoveNextAsync(It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(false)
        //        .Verifiable();
        //    _mockMongoCollection.Setup(m => m.FindAsync(
        //        It.IsAny<FilterDefinition<Claim>>(), It.IsAny<FindOptions<Claim, Claim>>(), It.IsAny<CancellationToken>())
        //        )
        //        .ReturnsAsync(mockCursor.Object)
        //        .Verifiable();
        //    _mockMongoCollection.Setup(m => m.FindOneAndUpdateAsync(
        //       It.IsAny<FilterDefinition<Claim>>(), It.IsAny<UpdateDefinition<Claim>>(), It.IsAny<FindOneAndUpdateOptions<Claim, Claim>>(), It.IsAny<CancellationToken>()))
        //       .Callback<FilterDefinition<Claim>, UpdateDefinition<Claim>, FindOneAndUpdateOptions<Claim, Claim>, CancellationToken>(
        //        (f, u, o, c) =>
        //        {
        //            claimToUpdate = BsonSerializer.Deserialize<Claim>(
        //                u.ToBsonDocument()
        //                .GetElement("Document")
        //                .Value.ToString());
        //        })
        //       .ReturnsAsync(claimToUpdate);
        //    // Act
        //    await _sut.UpdateClaimsStatuses(MBEClaim, 5);
        //    // Assert
        //    _mockMBEDBContext.Verify();
        //    _mockMongoCollection.Verify();
        //    Assert.InRange(claimToUpdate.createdDate, DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow);
        //    Assert.NotNull(claimToUpdate.claimNumber);
        //}

        //[Fact]
        //public async void StoreValuation_Should_UpdateValuation()
        //{
        //    // Arrange
        //    var claims = _fixture.Create<List<Claim>>();
        //    var claim = _fixture.Create<Claim>();
        //    var createdClaim = CreateClaim(claim);
        //    var storedClaim = CreateDbClaim(claim);
        //    Claim claimToUpdate = null;
        //    CreateDbClaim(createdClaim);
        //    var valuationDocuments = new Claim[] { storedClaim };
        //    var mockCursor = new Mock<IAsyncCursor<Claim>>();
        //    mockCursor.SetupGet(m => m.Current)
        //        .Returns(valuationDocuments)
        //        .Verifiable();
        //    mockCursor.SetupSequence(m => m.MoveNextAsync(It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(true)
        //        .ReturnsAsync(false);
        //    _mockMongoCollection.Setup(m => m.FindAsync(
        //        It.IsAny<FilterDefinition<Claim>>(), It.IsAny<FindOptions<Claim, Claim>>(), It.IsAny<CancellationToken>())
        //        )
        //        .ReturnsAsync(mockCursor.Object)
        //        .Verifiable();
        //    _mockMongoCollection.Setup(m => m.FindOneAndUpdateAsync(
        //       It.IsAny<FilterDefinition<Claim>>(), It.IsAny<UpdateDefinition<Claim>>(), It.IsAny<FindOneAndUpdateOptions<Claim, Claim>>(), It.IsAny<CancellationToken>()))
        //       .Callback<FilterDefinition<Claim>, UpdateDefinition<Claim>, FindOneAndUpdateOptions<Claim, Claim>, CancellationToken>(
        //        (f, u, o, c) =>
        //        {
        //            claimToUpdate = BsonSerializer.Deserialize<Claim>(
        //                u.ToBsonDocument()
        //                .GetElement("Document")
        //                .Value.ToString());
        //        })
        //       .ReturnsAsync(claimToUpdate);
        //    // Act
        //    await _sut.UpdateClaimsStatuses(claims, 5);
        //    // Assert
        //    _mockMBEDBContext.Verify();
        //    _mockMongoCollection.Verify();
        //    Assert.Equal(claimToUpdate.createdDate.ToString("yyyy-MM-ddTHH:mm:ss"), createdClaim.createdDate.ToString("yyyy-MM-ddTHH:mm:ss"));
        //    Assert.Equal(claimToUpdate.claimNumber, createdClaim.claimNumber);
        //    //Assert.Contains(claimToUpdate.claimNumber, g => g == claim.claimNumber);
        //    Assert.Equal(claimToUpdate.createdDate.ToString("yyyy-MM-ddTHH:mm:ss"), createdClaim.createdDate.ToString("yyyy-MM-ddTHH:mm:ss"));
        //    //Assert.All(claimToUpdate,
        //    //    p => claimToUpdate.Contains(p));
        //    Assert.Equal(claimToUpdate.claimNumber, createdClaim.claimNumber);
        //    Assert.Equal(claimToUpdate.claimNumber, createdClaim.claimNumber);
        //    Assert.Equal(claimToUpdate.claimNumber, createdClaim.claimNumber);
        //    Assert.Equal(claimToUpdate.claimNumber, createdClaim.claimNumber);
        //}
        #endregion

        #region Data Builders
        private static Claim CreateClaim(Claim claim)
        {
            var fixture = new Fixture();
            var result = claim.DeepClone();
            result.claimNumber = "sdfg";
            return result;
        }
        private static Claim CreateDbClaim(Claim valuation)
        {
            var fixture = new Fixture();
            var result = valuation.DeepClone();
            result.createdDate = DateTime.UtcNow;
            result.updatedDate = DateTime.UtcNow;
            return result;
        }
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
