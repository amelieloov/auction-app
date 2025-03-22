using GrupparbeteAuktion.Domain.Models;

namespace GrupparbeteAuktion.Data.Interfaces
{
    public interface IAuctionRepo
    {
        public void InsertItem(Auction auction);
        public void UpdateItem(Auction auction);
        public void DeleteItem(int auctionID);
        public List<Auction> SearchAuction(string condition);
        public Auction GetAuctionById(int AuctionIDSearch);
        public List<Auction> GetAuctionsByUserID(int userID);
    }
}
