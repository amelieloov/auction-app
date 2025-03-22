namespace GrupparbeteAuktion.Domain.Models
{
    public class Auction
    {
        public int AuctionID { get; set; }
        public string AuctionTitle { get; set; }
        public string AuctionDescription { get; set; }
        public decimal AuctionPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int UserID { get; set; }
        public Users User { get; set; }
        public string Image { get; set; }
        public List<Bid> Bids { get; set; }

        public Auction()
        {
        }
    }
}
