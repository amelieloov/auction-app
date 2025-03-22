using Dapper;
using GrupparbeteAuktion.Data.Interfaces;
using GrupparbeteAuktion.Domain.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GrupparbeteAuktion.Data.Repos
{
    public class BidRepo : IBidRepo
    {
        private readonly IAuctionDBContext _dbContext;

        public BidRepo(IAuctionDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBid(Bid bid)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@BidPrice", bid.BidPrice);
                parameters.Add("@AuctionID", bid.AuctionID);
                parameters.Add("@UserID", bid.UserID);


                db.Execute("AddBid", parameters, commandType: CommandType.StoredProcedure);

            }
        }
        public void DeleteBid(int BidID)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@BidID", BidID);

                db.Execute("DeleteBid", parameters, commandType: CommandType.StoredProcedure);

            }
        }
        public List<Bid> GetBids(int bidAuctionID) 
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@BidAuctionID", bidAuctionID);

                return
                db.Query<Bid, Users, Bid>("GetBidsByAuctionID", (b, u) =>
                {
                    b.User = u;
                    return b;
                },
                parameters, splitOn:"UserID", commandType: CommandType.StoredProcedure).ToList();
                
            }
        }
        public Bid GetBidByID(int bidID)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@BidID", bidID);

                return
                    db.Query<Bid>("GetBidByID", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                
            }
        }

        public List<Bid> GetBidsByUserID(int userID)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@UserID", userID);

                return
                db.Query<Bid, Auction, Users, Bid>("GetBidsByUserID", (b, a, u) =>
                {
                    b.Auction = a;
                    b.User = u;
                    return b;
                },
                parameters, splitOn: "AuctionID, UserID", commandType: CommandType.StoredProcedure).ToList();

            }
        }
    }
}
