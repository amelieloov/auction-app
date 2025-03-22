using Dapper;
using GrupparbeteAuktion.Data.Interfaces;
using GrupparbeteAuktion.Domain.Models;
using System.Data;

namespace GrupparbeteAuktion.Data.Repos
{
    public class AuctionRepo : IAuctionRepo
    {
        private readonly IAuctionDBContext _dbContext;

        public AuctionRepo(IAuctionDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void InsertItem(Auction auction)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@AuctionTitle", auction.AuctionTitle);
                parameters.Add("@AuctionDescription", auction.AuctionDescription);
                parameters.Add("@AuctionPrice", auction.AuctionPrice);
                parameters.Add("@StartTime", auction.StartTime);
                parameters.Add("@EndTime", auction.EndTime);
                parameters.Add("@UserId", auction.UserID);
                parameters.Add("@Image", auction.Image);

                db.Execute("InsertItem", parameters, commandType: CommandType.StoredProcedure);

            }
        }
        public void UpdateItem(Auction auction)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@AuctionID", auction.AuctionID);
                parameters.Add("@AuctionTitle", auction.AuctionTitle);
                parameters.Add("@AuctionDescription", auction.AuctionDescription);
                parameters.Add("@AuctionPrice", auction.AuctionPrice);
                parameters.Add("@StartTime", auction.StartTime);
                parameters.Add("@EndTime", auction.EndTime);
                parameters.Add("@Image", auction.Image);

                db.Execute("UpdateItem", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public void DeleteItem(int auctionID)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@AuctionID", auctionID);

                db.Execute("DeleteItem", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public List<Auction>SearchAuction(string condition)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Title", condition);

                var auctions = db.Query<Auction, Users, Auction>("SearchAuction", (a, u) =>
                {
                    a.User = u;
                    return a;
                }, 
                parameters, splitOn: "UserID", commandType: CommandType.StoredProcedure).ToList();
                return auctions;
            }
        }

        public Auction GetAuctionById(int AuctionIDSearch)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@AuctionIDSearch", AuctionIDSearch);

                var auction = db.Query<Auction, Users, Auction>("GetAuctionById", (a, u) =>
                {
                    a.User = u;
                    return a;
                }, 
                parameters, splitOn: "UserID", commandType: CommandType.StoredProcedure).FirstOrDefault();
                return auction;
            }
        }

        public List<Auction> GetAuctionsByUserID(int userID)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@UserID", userID);

                var auctions = db.Query<Auction>("GetAuctionsByUserID", parameters, commandType: CommandType.StoredProcedure).ToList();
                return auctions;
            }
        }
    }
}
