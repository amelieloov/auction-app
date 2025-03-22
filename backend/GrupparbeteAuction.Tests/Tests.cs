using Dapper;
using GrupparbeteAuktion.Core.Services;
using GrupparbeteAuktion.Data.Interfaces;
using GrupparbeteAuktion.Data.Repos;
using GrupparbeteAuktion.Domain.Models;
using Moq;
using Moq.Dapper;
using System.Data;


namespace GrupparbeteAuction.Tests
{
    public class Tests
    {
        [Fact]
        public void TestIsAuctionClosed_IfAuctionHasEnded_ShouldReturnTrue()
        {
            //Arrange
            var auction = new Auction
            {
                EndTime = DateTime.Now.AddHours(-2)
            };

            var service = new AuctionService(null, null, null, null);

            //Act
            var result = service.IsClosed(auction);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestGetAuctionById_ReturnsCorrectAuction()
        {
            // Arrange
            var expectedAuction = new Auction { AuctionID = 1, AuctionTitle = "Title", AuctionDescription = "Desc",
                AuctionPrice = 100, StartTime = DateTime.Now, EndTime = DateTime.Now};

            var mockDbContext = new Mock<IAuctionDBContext>();
            var mockDbConnection = new Mock<IDbConnection>();

            mockDbContext.Setup(c => c.GetConnection()).Returns(mockDbConnection.Object);

            mockDbConnection.SetupDapper(c => c.QueryFirstOrDefault<Auction>(
                "GetAuctionById",
                It.IsAny<DynamicParameters>(),
                null,
                null,
                CommandType.StoredProcedure
            )).Returns(expectedAuction);

            var repo = new AuctionRepo(mockDbContext.Object);

            // Act
            var result = repo.GetAuctionById(1);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestGetBidsById_returns_correct_bids()
        {
            // Arrange
            var expectedBids = new List<Bid>
            {
                new Bid { BidID = 1, BidPrice = 100 },
                new Bid { BidID = 2, BidPrice = 200 },
                new Bid { BidID = 3, BidPrice = 300 }
            };

            var mockDbContext = new Mock<IAuctionDBContext>();
            var mockDbConnection = new Mock<IDbConnection>();

            mockDbContext.Setup(c => c.GetConnection()).Returns(mockDbConnection.Object);

            mockDbConnection.SetupDapper(c => c.Query<Bid>(
                "GetBids",
                It.IsAny<DynamicParameters>(),
                null,
                true,
                null,
                CommandType.StoredProcedure
            )).Returns(expectedBids);

            var repo = new BidRepo(mockDbContext.Object);

            // Act
            var result = repo.GetBids(1);

            // Assert
            Assert.NotNull(result);
        }
    }
}