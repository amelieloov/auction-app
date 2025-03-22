namespace GrupparbeteAuktion.Domain.Models
{
    public class Bid
    {
        public int BidID { get; set; }
        public Auction Auction { get; set; }
        public Users User { get; set; }

        public decimal BidPrice { get; set; }
        public int UserID { get; set; }
        public int AuctionID    { get; set; }

        public Bid() 
        {
        }
    }
}
