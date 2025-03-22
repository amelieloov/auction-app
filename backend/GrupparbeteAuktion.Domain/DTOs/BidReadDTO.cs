using GrupparbeteAuktion.Domain.Models;

namespace GrupparbeteAuktion.Domain.DTOs
{
    public class BidReadDTO
    {
        public int BidID { get; set; }
        public decimal BidPrice { get; set; }
        public int UserID { get; set; }
        public Users User { get; set; }
    }
}
