using AutoFixture;
using MobileClaimJobs.Interfaces;
using MobileClaimJobs.Models;
using MobileClaimJobs.Repositories;
using MobileClaimJobs.ScheduledJobs;
using MongoDB.Bson;
using Moq;
using Newtonsoft.Json.Bson;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MobileClaimJobs.Test.UnitTests.Jobs
{
    public class ClaimsJobTests
    {
        #region Private members
        private ClaimsJob _sut;
        private Mock<IMBERepository> _mockMBERepository;
        private Mock<MBEDBContext> _mockMBEDBContext;
        private Fixture _fixture;
        public ClaimsJobTests()
        {
            _fixture = new Fixture();
            _mockMBERepository = new Mock<IMBERepository>();
            _sut = new ClaimsJob(_mockMBERepository.Object);
        }
        #endregion
        [Fact]
        public async void Execute_Should_RunSuccesfully()
        {
            // Arrange
            var mockJobExecutionContext = new Mock<IJobExecutionContext>();
            var claims = _fixture.Build<Claim>()
                .With(u => u.Id, new MongoDB.Bson.BsonObjectId(new ObjectId("bc299553e0fe4daa8de48d312a280e4e")))
                .CreateMany<Claim>(new Random().Next(100));
            _mockMBERepository.Setup(m => m.GetEligibleEstimateStatusClaims())
                .ReturnsAsync(claims.ToList())
                .Verifiable();
            _mockMBERepository.Setup(m => m.UpdateClaimsStatuses(It.IsAny<List<Claim>>(), It.IsAny<int>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            // Act
            await _sut.Execute(mockJobExecutionContext.Object);
            // Assert
            _mockMBERepository.Verify();
        }

        //[Fact]
        //public async void Execute_Should_ThrowException_When_GadgetApiFails()
        //{
        //    // Arrange
        //    var mockJobExecutionContext = new Mock<IJobExecutionContext>();
        //    var claims = _fixture.Build<Claim>()
        //        .With(u => u.Id, new MongoDB.Bson.BsonObjectId(new ObjectId("bc299553e0fe4daa8de48d312a280e4e")))
        //        .CreateMany<Claim>(new Random().Next(100));
        //    _mockMBERepository.Setup(m => m.GetEligibleEstimateStatusClaims())
        //        .ReturnsAsync(claims.ToList())
        //        .Verifiable();
        //    // Act
        //    var result = await Assert.ThrowsAsync<Exception>(() =>
        //        _sut.Execute(mockJobExecutionContext.Object)
        //    );
        //    // Assert
        //    //_mockMBERepository.Verify();
        //    Assert.NotNull(result);
        //    Assert.NotEmpty(result.Message);
        //}
    }
}
