using GrupparbeteAuktion.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace GrupparbeteAuktion.Domain.DTOs
{
    public class AuctionCreateDTO
    {
        public string AuctionTitle { get; set; }
        public string AuctionDescription { get; set; }
        public decimal AuctionPrice { get; set; }
        public DateTime EndTime { get; set; }
        public IFormFile Image {  get; set; }
    }
}
