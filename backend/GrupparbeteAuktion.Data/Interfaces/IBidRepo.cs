using GrupparbeteAuktion.Domain.Models;

namespace GrupparbeteAuktion.Data.Interfaces
{
    public interface IBidRepo
    {
        public void AddBid(Bid bid);
        public void DeleteBid(int BidID);
        public List<Bid> GetBids(int bidAuctionID);
        public Bid GetBidByID(int bidID);
        public List<Bid> GetBidsByUserID(int userID);


    }
}
