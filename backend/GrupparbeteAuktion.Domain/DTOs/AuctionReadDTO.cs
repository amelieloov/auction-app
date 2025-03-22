using GrupparbeteAuktion.Domain.Models;

namespace GrupparbeteAuktion.Domain.DTOs
{
    public class AuctionReadDTO
    {
        public string AuctionID { get; set; }
        public string AuctionTitle { get; set; }
        public string AuctionDescription { get; set; }
        public int AuctionPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int UserID { get; set; }
        public Users User { get; set; }
        public List<BidReadDTO> Bids { get; set; }
        public string Image { get; set; }
    }
}
